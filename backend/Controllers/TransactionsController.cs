using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using System;
using System.Threading.Tasks;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransactionsController(AppDbContext context)
    {
        _context = context;
    }

    // POST: api/transactions/accept-bid
    [HttpPost("accept-bid")]
    public async Task<IActionResult> AcceptBid([FromBody] AcceptBidRequest request)
    {
        var bid = await _context.Bids
            .Include(b => b.Ad)
            .Include(b => b.Carrier)
                .ThenInclude(c => c!.CarrierProfile)
            .FirstOrDefaultAsync(b => b.Id == request.BidId);

        if (bid == null)
        {
            return NotFound(new { message = "Teklif bulunamadı." });
        }

        var ad = bid.Ad;
        if (ad == null)
        {
            return NotFound(new { message = "İlan bulunamadı." });
        }

        if (ad.Status != "Active")
        {
            return BadRequest(new { message = "Bu ilan için ihale süreci aktif değil (zaten tamamlanmış veya iptal edilmiş)." });
        }

        var sender = await _context.Users.FindAsync(ad.SenderId);
        if (sender == null)
        {
            return NotFound(new { message = "Gönderici bulunamadı." });
        }

        var carrier = bid.Carrier;
        if (carrier == null)
        {
            return NotFound(new { message = "Taşıyıcı bulunamadı." });
        }

        // --- PRE-AUTH BLOKAJ HESAPLAMALARI ---
        
        // 1. Gönderici Navlun Bedeli Blokajı (100% of Bid Amount)
        decimal senderBlockAmount = bid.Amount;
        if (sender.Balance < senderBlockAmount)
        {
            return BadRequest(new 
            { 
                message = $"Yetersiz Gönderici Bakiyesi! Göndericinin bakiyesi ({sender.Balance:C2}), teklif tutarını ({senderBlockAmount:C2}) karşılamıyor." 
            });
        }

        // 2. Taşıyıcı Güvence Teminatı Blokajı (Level Bazlı)
        decimal carrierBlockAmount = 0m;
        string blockageDetail = "";

        if (carrier.UserLevel == 1)
        {
            // Level 1: 100% of Cargo Value
            carrierBlockAmount = ad.CargoValue;
            blockageDetail = $"Level 1 Taşıyıcı için Kargo Değerinin %100'ü oranında teminat bloke edilmiştir: {carrierBlockAmount:C2}";
            
            if (carrier.Balance < carrierBlockAmount)
            {
                return BadRequest(new 
                { 
                    message = $"Yetersiz Taşıyıcı Bakiyesi! Level 1 taşıyıcıların kargo bedelinin %100'ünü ({carrierBlockAmount:C2}) teminat olarak bloke etmesi gerekmektedir. Taşıyıcı bakiye: {carrier.Balance:C2}." 
                });
            }
        }
        else if (carrier.UserLevel == 2)
        {
            // Level 2: 30% of Cargo Value
            carrierBlockAmount = Math.Round(ad.CargoValue * 0.30m, 2);
            blockageDetail = $"Level 2 Taşıyıcı için Kargo Değerinin %30'u oranında kısmi teminat bloke edilmiştir: {carrierBlockAmount:C2}";

            if (carrier.Balance < carrierBlockAmount)
            {
                return BadRequest(new 
                { 
                    message = $"Yetersiz Taşıyıcı Bakiyesi! Level 2 taşıyıcıların kargo bedelinin %30'unu ({carrierBlockAmount:C2}) kısmi teminat olarak bloke etmesi gerekmektedir. Taşıyıcı bakiye: {carrier.Balance:C2}." 
                });
            }
        }
        else if (carrier.UserLevel == 3)
        {
            // Level 3: 0% blockage (Verified Insurance check)
            if (carrier.CarrierProfile == null || string.IsNullOrWhiteSpace(carrier.CarrierProfile.InsuranceNo))
            {
                return BadRequest(new 
                { 
                    message = "Geçersiz Seviye 3 Taşıyıcı! Level 3 taşıyıcıların aktif bir ticari sigorta poliçesi (InsuranceNo) bulunmalıdır." 
                });
            }
            carrierBlockAmount = 0m;
            blockageDetail = $"Level 3 Taşıyıcı için {carrier.CarrierProfile.InsuranceNo} nolu Sigorta Poliçesi onaylanmış ve %0 bakiye blokajı uygulanmıştır.";
        }
        else
        {
            return BadRequest(new { message = "Geçersiz taşıyıcı yetki seviyesi." });
        }

        // --- PROVİZYON GERÇEKLEŞTİRME ---
        
        // Gönderici bakiyesini bloke et
        sender.Balance -= senderBlockAmount;
        
        // Taşıyıcı bakiyesini bloke et
        carrier.Balance -= carrierBlockAmount;

        // İhale onaylama işlemleri
        bid.Status = "Accepted";
        ad.Status = "InTransit";

        // Diğer teklifleri reddet
        var otherBids = await _context.Bids
            .Where(b => b.AdId == ad.Id && b.Id != bid.Id)
            .ToListAsync();
        foreach (var ob in otherBids)
        {
            ob.Status = "Rejected";
        }

        // İşlem (Transaction) kaydı oluştur
        var authCode = "AUTH-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        var transaction = new Transaction
        {
            BidId = bid.Id,
            AuthCode = authCode,
            AmountBlockedSender = senderBlockAmount,
            AmountBlockedCarrier = carrierBlockAmount,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return Ok(new 
        { 
            message = "İhale kabul edildi, ön provizyon süreci başarıyla tamamlandı.",
            transactionId = transaction.Id,
            authCode = transaction.AuthCode,
            senderBlocked = transaction.AmountBlockedSender,
            carrierBlocked = transaction.AmountBlockedCarrier,
            blockageMessage = blockageDetail,
            senderNewBalance = sender.Balance,
            carrierNewBalance = carrier.Balance,
            adStatus = ad.Status
        });
    }

    // POST: api/transactions/complete/5
    [HttpPost("complete/{id}")]
    public async Task<IActionResult> CompleteTransaction(int id, [FromBody] CompleteTransactionRequest request)
    {
        var transaction = await _context.Transactions
            .Include(t => t.Bid)
                .ThenInclude(b => b!.Ad)
            .Include(t => t.Bid)
                .ThenInclude(b => b!.Carrier)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (transaction == null)
        {
            return NotFound(new { message = "İşlem kaydı bulunamadı." });
        }

        if (transaction.Status != "Blocked")
        {
            return BadRequest(new { message = "Bu taşıma işlemi tamamlanmak için uygun değil (zaten tamamlanmış veya iptal edilmiş)." });
        }

        if (!request.IsVerifiedByAi)
        {
            return BadRequest(new { message = "Yapay Zeka denetimi başarısız olan teslimatlar onaylanamaz." });
        }

        var bid = transaction.Bid;
        if (bid == null || bid.Ad == null || bid.Carrier == null)
        {
            return BadRequest(new { message = "İşlem ilişkili verilerinde eksiklik var." });
        }

        var ad = bid.Ad;
        var carrier = bid.Carrier;
        var sender = await _context.Users.FindAsync(ad.SenderId);
        if (sender == null)
        {
            return NotFound(new { message = "Gönderici bulunamadı." });
        }

        // --- TAŞIMA TAMAMLAMA / GÜVENCE TEMİNATI SERBEST BIRAKMA VE NAVLUN TRANSFERİ ---
        
        // 1. Taşıyıcı Güvence Teminatını İade Et (Release Carrier Hold)
        carrier.Balance += transaction.AmountBlockedCarrier;

        // 2. Göndericiden Bloke Edilen Navlun Bedelini Taşıyıcıya Aktar (Capture Sender Payment to Carrier)
        decimal payoutAmount = transaction.AmountBlockedSender;
        decimal bonusAmount = 0m;
        
        if (carrier.WelcomeBonusExpiry.HasValue && carrier.WelcomeBonusExpiry.Value > DateTime.UtcNow)
        {
            // +10% welcome bonus payout
            bonusAmount = Math.Round(payoutAmount * 0.10m, 2);
        }

        carrier.Balance += (payoutAmount + bonusAmount);

        // Durumları Güncelle
        transaction.Status = "Captured";
        transaction.DeliveryImageUrl = request.DeliveryImageUrl;
        transaction.IsVerifiedByAi = request.IsVerifiedByAi;
        ad.Status = "Completed";

        await _context.SaveChangesAsync();

        return Ok(new 
        { 
            message = bonusAmount > 0 
                ? $"Kargo teslimatı tamamlandı. Hoş Geldin Bonusu (%10) uygulandı: +{bonusAmount} TL ekstra bakiye eklendi!"
                : "Kargo teslimatı tamamlandı. Ödemeler gerçekleştirildi ve güvence blokajları serbest bırakıldı.",
            transactionStatus = transaction.Status,
            adStatus = ad.Status,
            senderBalance = sender.Balance,
            carrierBalance = carrier.Balance,
            payoutTransferred = payoutAmount,
            bonusApplied = bonusAmount,
            carrierCollateralReleased = transaction.AmountBlockedCarrier
        });
    }

    // GET: api/transactions/history
    [HttpGet("history")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetHistory()
    {
        return await _context.Transactions
            .Include(t => t.Bid)
                .ThenInclude(b => b!.Ad)
            .Include(t => t.Bid)
                .ThenInclude(b => b!.Carrier)
            .OrderByDescending(t => t.Id)
            .ToListAsync();
    }

    // POST: api/transactions/{id}/status
    [HttpPost("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusRequest request)
    {
        var transaction = await _context.Transactions
            .Include(t => t.Bid)
                .ThenInclude(b => b!.Ad)
            .Include(t => t.Bid)
                .ThenInclude(b => b!.Carrier)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (transaction == null)
        {
            return NotFound(new { message = "İşlem bulunamadı." });
        }

        if (request.Status == "InTransit")
        {
            transaction.Status = "InTransit";
            if (transaction.Bid?.Ad != null)
            {
                transaction.Bid.Ad.Status = "InTransit";
            }
            await _context.SaveChangesAsync();
            return Ok(new { message = "Taşıma başlatıldı." });
        }
        else if (request.Status == "Delivered" || request.Status == "Captured")
        {
            var bid = transaction.Bid;
            if (bid == null || bid.Ad == null || bid.Carrier == null)
            {
                return BadRequest(new { message = "İşlem ilişkili verilerinde eksiklik var." });
            }

            var ad = bid.Ad;
            var carrier = bid.Carrier;
            var sender = await _context.Users.FindAsync(ad.SenderId);
            if (sender == null)
            {
                return NotFound(new { message = "Gönderici bulunamadı." });
            }

            // 1. Taşıyıcı Güvence Teminatını İade Et (Release Carrier Hold)
            carrier.Balance += transaction.AmountBlockedCarrier;

            // 2. Göndericiden Bloke Edilen Navlun Bedelini Taşıyıcıya Aktar (Capture Sender Payment to Carrier)
            decimal payoutAmount = transaction.AmountBlockedSender;
            decimal bonusAmount = 0m;
            
            if (carrier.WelcomeBonusExpiry.HasValue && carrier.WelcomeBonusExpiry.Value > DateTime.UtcNow)
            {
                bonusAmount = Math.Round(payoutAmount * 0.10m, 2);
            }

            carrier.Balance += (payoutAmount + bonusAmount);

            // Durumları Güncelle
            transaction.Status = "Delivered";
            transaction.DeliveryImageUrl = request.DeliveryImageUrl ?? "";
            transaction.IsVerifiedByAi = true;
            ad.Status = "Completed";

            await _context.SaveChangesAsync();

            return Ok(new 
            { 
                message = "Kargo teslimatı tamamlandı ve ödemeler aktarıldı.",
                transactionStatus = transaction.Status,
                adStatus = ad.Status,
                senderBalance = sender.Balance,
                carrierBalance = carrier.Balance
            });
        }

        return BadRequest(new { message = "Geçersiz durum güncellemesi." });
    }
}

public class AcceptBidRequest
{
    public int BidId { get; set; }
}

public class CompleteTransactionRequest
{
    public string DeliveryImageUrl { get; set; } = string.Empty;
    public bool IsVerifiedByAi { get; set; }
}

public class UpdateStatusRequest
{
    public string Status { get; set; } = string.Empty;
    public string? DeliveryImageUrl { get; set; }
}
