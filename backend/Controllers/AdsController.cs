using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/ads
    // Optional query parameter level to filter ads carrier can bid on.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ad>>> GetAds([FromQuery] int? level)
    {
        var ads = await _context.Ads
            .Include(a => a.Bids)
                .ThenInclude(b => b.Carrier)
            .OrderByDescending(a => a.Id)
            .ToListAsync();

        // Check and resolve expired ads dynamically
        foreach (var ad in ads.Where(a => a.Status == "Active" && a.AuctionEndsAt < DateTime.UtcNow).ToList())
        {
            await CheckAndResolveExpiredAd(ad);
        }

        if (level.HasValue)
        {
            ads = ads.Where(a => a.RequiredLevel <= level.Value).ToList();
        }

        return ads;
    }

    // GET: api/ads/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Ad>> GetAd(int id)
    {
        var ad = await _context.Ads
            .Include(a => a.Bids)
                .ThenInclude(b => b.Carrier)
                    .ThenInclude(c => c!.CarrierProfile)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (ad == null)
        {
            return NotFound(new { message = "İlan bulunamadı." });
        }

        if (ad.Status == "Active" && ad.AuctionEndsAt < DateTime.UtcNow)
        {
            await CheckAndResolveExpiredAd(ad);
        }

        return ad;
    }

    // POST: api/ads
    [HttpPost]
    public async Task<ActionResult<Ad>> PostAd([FromBody] CreateAdDto dto)
    {
        var sender = await _context.Users.FindAsync(dto.SenderId);
        if (sender == null || sender.UserType != "Sender")
        {
            return BadRequest(new { message = "Geçersiz gönderici kimliği." });
        }

        // Calculate Floor Price:
        // (Distance * (ConsumptionRate / 100) * FuelPrice) + BaseFee (500) + (CargoValue * RiskFactor (0.001))
        decimal fuelCost = (decimal)dto.DistanceKm * ((decimal)dto.FuelConsumptionRate / 100m) * SystemConfig.CurrentFuelPrice;
        decimal baseFee = 500m;
        decimal riskFee = dto.CargoValue * 0.001m;
        decimal calculatedFloorPrice = Math.Round(fuelCost + baseFee + riskFee, 2);

        var ad = new Ad
        {
            SenderId = dto.SenderId,
            Title = dto.Title,
            Description = dto.Description,
            StartLocation = dto.StartLocation,
            EndLocation = dto.EndLocation,
            DistanceKm = dto.DistanceKm,
            FuelConsumptionRate = dto.FuelConsumptionRate,
            CargoValue = dto.CargoValue,
            FloorPrice = calculatedFloorPrice,
            RequiredLevel = dto.RequiredLevel,
            Status = "Active",
            CargoImageUrl = dto.CargoImageUrl ?? "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80",
            VerificationCode = "LY-" + new Random().Next(1000, 9999).ToString(),
            AuctionEndsAt = DateTime.UtcNow.AddMinutes(10) // Demo ends in 10 minutes
        };

        _context.Ads.Add(ad);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAd), new { id = ad.Id }, ad);
    }

    // POST: api/ads/{id}/instant-book
    [HttpPost("{id}/instant-book")]
    public async Task<IActionResult> InstantBook(int id, [FromBody] InstantBookPayload payload)
    {
        var ad = await _context.Ads.FindAsync(id);
        if (ad == null)
        {
            return NotFound(new { message = "İlan bulunamadı." });
        }

        if (ad.Status != "Active")
        {
            return BadRequest(new { message = "Bu ilan aktif değil." });
        }

        var carrier = await _context.Users.FindAsync(payload.CarrierId);
        if (carrier == null || carrier.UserType != "Carrier")
        {
            return BadRequest(new { message = "Geçersiz taşıyıcı." });
        }

        ad.Status = "BiddingClosed";
        
        var bid = new Bid
        {
            AdId = id,
            CarrierId = payload.CarrierId,
            Amount = ad.InstantBookPrice ?? ad.FloorPrice,
            Status = "Accepted"
        };
        _context.Bids.Add(bid);

        var notification = new Notification
        {
            UserId = ad.SenderId,
            Title = "İlanınız Anında Rezerve Edildi!",
            Message = $"'{ad.Title}' başlıklı ilanınız {carrier.Name} tarafından anında rezervasyon fiyatıyla kabul edildi.",
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };
        _context.Notifications.Add(notification);

        await _context.SaveChangesAsync();
        return Ok(bid);
    }

    // POST: api/ads/{id}/assign-driver
    [HttpPost("{id}/assign-driver")]
    public async Task<IActionResult> AssignDriver(int id, [FromBody] AssignDriverPayload payload)
    {
        var ad = await _context.Ads.FindAsync(id);
        if (ad == null)
        {
            return NotFound(new { message = "İlan bulunamadı." });
        }

        var driver = await _context.Users.FindAsync(payload.DriverId);
        if (driver == null)
        {
            return NotFound(new { message = "Şoför bulunamadı." });
        }

        ad.AssignedDriverId = payload.DriverId;

        var notification = new Notification
        {
            UserId = payload.DriverId,
            Title = "Yeni Taşıma Görevi Atandı",
            Message = $"Filo yöneticiniz size '{ad.Title}' taşıma görevini atadı.",
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };
        _context.Notifications.Add(notification);

        await _context.SaveChangesAsync();
        return Ok(new { success = true, ad });
    }

    // POST: api/ads/{id}/upload-waybill
    [HttpPost("{id}/upload-waybill")]
    public async Task<IActionResult> UploadWaybill(int id, [FromBody] UploadWaybillPayload payload)
    {
        var ad = await _context.Ads.FindAsync(id);
        if (ad == null)
        {
            return NotFound(new { message = "İlan bulunamadı." });
        }

        if (payload.WaybillUrl == "INVALID_IMAGE")
        {
            return BadRequest(new { success = false, message = "Hata: Yüklenen resimde geçerli bir Sevk İrsaliyesi bulunamadı. Yapay Zeka doğrulama motoru belgeyi tespit edemedi." });
        }

        if (payload.WaybillUrl == "WRONG_WAYBILL")
        {
            return BadRequest(new { success = false, message = "Hata: Belge okundu fakat bu irsaliye başka bir sevkiyata ait (İlan ID: " + (id + 99) + " uyuşmazlığı)." });
        }

        ad.WaybillUrl = payload.WaybillUrl ?? "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80";
        ad.WaybillOcrText = "LojistikYol A.Ş. Sevk İrsaliyesi\nİlan ID: " + id + "\nÜrün: Koli Paketleri\nAdet: 5\nTarih: " + DateTime.Now.ToString("dd/MM/yyyy") + "\nDoğrulama: Başarılı (AI Uyuşması Tam)";

        await _context.SaveChangesAsync();
        return Ok(new { success = true, ocrText = ad.WaybillOcrText });
    }

    // POST: api/ads/sender/rate
    [HttpPost("sender/rate")]
    public async Task<IActionResult> RateSender([FromBody] RateSenderPayload payload)
    {
        var sender = await _context.Users.FindAsync(payload.SenderId);
        if (sender == null)
        {
            return NotFound(new { message = "Gönderici bulunamadı." });
        }

        var review = new SenderReview
        {
            AdId = payload.AdId,
            SenderId = payload.SenderId,
            CarrierId = payload.CarrierId,
            Score = payload.Score,
            Comment = payload.Comment ?? string.Empty,
            CreatedAt = DateTime.UtcNow
        };
        _context.SenderReviews.Add(review);

        var reviews = await _context.SenderReviews.Where(r => r.SenderId == payload.SenderId).ToListAsync();
        double sum = reviews.Sum(r => r.Score) + payload.Score;
        int count = reviews.Count + 1;
        sender.SenderRating = Math.Round(sum / count, 1);
        sender.SenderRatingCount = count;

        var notification = new Notification
        {
            UserId = payload.SenderId,
            Title = "Yeni Değerlendirme Alındı",
            Message = $"Bir taşıyıcı size {payload.Score} yıldız verdi ve yorum yaptı.",
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };
        _context.Notifications.Add(notification);

        await _context.SaveChangesAsync();
        return Ok(review);
    }

    private async Task CheckAndResolveExpiredAd(Ad ad)
    {
        ad.Status = "BiddingClosed";

        // Find lowest bid
        var bids = ad.Bids.Where(b => b.Status == "Pending").ToList();
        if (bids.Any())
        {
            var winningBid = bids.OrderBy(b => b.Amount).First();
            winningBid.Status = "Accepted";

            // Mark others rejected
            foreach (var b in bids.Where(b => b.Id != winningBid.Id))
            {
                b.Status = "Rejected";
            }

            // Create a Transaction!
            var tx = new Transaction
            {
                BidId = winningBid.Id,
                Status = "Pending", // Yola çıkmaya hazır
                CreatedAt = DateTime.UtcNow,
                AmountBlockedSender = winningBid.Amount,
                AmountBlockedCarrier = winningBid.Amount * 0.05m // 5% guarantee fee
            };
            _context.Transactions.Add(tx);

            // Add Notifications
            var senderNotification = new Notification
            {
                UserId = ad.SenderId,
                Title = "İhale Süresi Doldu - Kazanan Belirlendi!",
                Message = $"'{ad.Title}' başlıklı ilanınızın süresi doldu. En düşük teklifi veren {winningBid.Carrier?.Name ?? "Mehmet Usta"} (₺{winningBid.Amount}) ihaleyi kazandı. Sevkiyat onay bekliyor.",
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };
            _context.Notifications.Add(senderNotification);

            var carrierNotification = new Notification
            {
                UserId = winningBid.CarrierId,
                Title = "Tebrikler! İhaleyi Kazandınız!",
                Message = $"'{ad.Title}' başlıklı ilanda verdiğiniz ₺{winningBid.Amount} teklif en düşük teklif olduğu için ihale üzerinizde kaldı. Sevkiyat hazır!",
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };
            _context.Notifications.Add(carrierNotification);
        }
        else
        {
            // No bids placed, mark cancelled
            var senderNotification = new Notification
            {
                UserId = ad.SenderId,
                Title = "İhale Süresi Doldu - Teklif Yok",
                Message = $"'{ad.Title}' başlıklı ilanınıza ihale süresi boyunca hiçbir teklif verilmedi.",
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };
            _context.Notifications.Add(senderNotification);
        }

        await _context.SaveChangesAsync();
    }

    // POST: api/ads/carrier/rate
    [HttpPost("carrier/rate")]
    public async Task<IActionResult> RateCarrier([FromBody] RateCarrierPayload payload)
    {
        var carrier = await _context.Users.FindAsync(payload.CarrierId);
        if (carrier == null)
        {
            return NotFound(new { message = "Taşıyıcı bulunamadı." });
        }

        var carrierProfile = await _context.CarrierProfiles.FirstOrDefaultAsync(p => p.UserId == payload.CarrierId);
        if (carrierProfile == null)
        {
            return BadRequest(new { message = "Taşıyıcı profili bulunamadı." });
        }

        double currentRating = carrierProfile.Rating;
        carrierProfile.Rating = Math.Round((currentRating * 4 + payload.Score) / 5.0, 1);

        var notification = new Notification
        {
            UserId = payload.CarrierId,
            Title = "Yeni Değerlendirme Alındı",
            Message = $"İlan sahibi size {payload.Score} yıldız verdi ve yorum yaptı.",
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };
        _context.Notifications.Add(notification);

        await _context.SaveChangesAsync();
        return Ok(new { message = "Taşıyıcı değerlendirildi.", newRating = carrierProfile.Rating });
    }
}

public class CreateAdDto
{
    public int SenderId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string StartLocation { get; set; } = string.Empty;
    public string EndLocation { get; set; } = string.Empty;
    public double DistanceKm { get; set; }
    public double FuelConsumptionRate { get; set; } = 30.0;
    public decimal CargoValue { get; set; }
    public int RequiredLevel { get; set; } = 1;
    public string? CargoImageUrl { get; set; }
}

public class InstantBookPayload
{
    public int CarrierId { get; set; }
}

public class AssignDriverPayload
{
    public int DriverId { get; set; }
}

public class UploadWaybillPayload
{
    public string? WaybillUrl { get; set; }
}

public class RateSenderPayload
{
    public int AdId { get; set; }
    public int SenderId { get; set; }
    public int CarrierId { get; set; }
    public int Score { get; set; }
    public string? Comment { get; set; }
}

public class RateCarrierPayload
{
    public int AdId { get; set; }
    public int CarrierId { get; set; }
    public int SenderId { get; set; }
    public int Score { get; set; }
    public string? Comment { get; set; }
}
