using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BidsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BidsController(AppDbContext context)
    {
        _context = context;
    }

    // POST: api/bids
    [HttpPost]
    public async Task<IActionResult> PlaceBid([FromBody] CreateBidDto dto)
    {
        var carrier = await _context.Users
            .Include(u => u.CarrierProfile)
            .FirstOrDefaultAsync(u => u.Id == dto.CarrierId);

        if (carrier == null || carrier.UserType != "Carrier")
        {
            return BadRequest(new { message = "Geçersiz taşıyıcı kimliği." });
        }

        var ad = await _context.Ads.FindAsync(dto.AdId);
        if (ad == null)
        {
            return NotFound(new { message = "İlan bulunamadı." });
        }

        if (ad.Status != "Active")
        {
            return BadRequest(new { message = "Bu ilan aktif teklif toplama sürecinde değil." });
        }

        // Rule FR2: Carrier level check
        if (carrier.UserLevel < ad.RequiredLevel)
        {
            return BadRequest(new 
            { 
                message = $"Bu ilana teklif vermek için minimum Level {ad.RequiredLevel} gereklidir. Sizin seviyeniz: Level {carrier.UserLevel}." 
            });
        }

        // Rule FR3: Bid cannot be below floor price
        if (dto.Amount < ad.FloorPrice)
        {
            return BadRequest(new 
            { 
                message = $"Teklif tutarı ({dto.Amount:C2}), taban fiyatın ({ad.FloorPrice:C2}) altında olamaz!" 
            });
        }

        // Check if there is an existing bid for this carrier
        var existingBid = await _context.Bids
            .FirstOrDefaultAsync(b => b.AdId == dto.AdId && b.CarrierId == dto.CarrierId);

        if (existingBid != null)
        {
            existingBid.Amount = dto.Amount;
            existingBid.IsAutoBidEnabled = dto.IsAutoBidEnabled;
            existingBid.AutoBidMinLimit = dto.AutoBidMinLimit;
            existingBid.Status = "Pending";
            await _context.SaveChangesAsync();
            
            await RunAutoBiddingEngine(dto.AdId, existingBid.Id);
            
            return Ok(new { message = "Teklifiniz güncellendi.", bid = existingBid });
        }

        var bid = new Bid
        {
            AdId = dto.AdId,
            CarrierId = dto.CarrierId,
            Amount = dto.Amount,
            IsAutoBidEnabled = dto.IsAutoBidEnabled,
            AutoBidMinLimit = dto.AutoBidMinLimit,
            Status = "Pending"
        };

        _context.Bids.Add(bid);
        await _context.SaveChangesAsync();

        await RunAutoBiddingEngine(dto.AdId, bid.Id);

        return CreatedAtAction(nameof(PlaceBid), new { id = bid.Id }, new { message = "Teklif başarıyla yerleştirildi.", bid });
    }

    // GET: api/bids/carrier/5
    [HttpGet("carrier/{carrierId}")]
    public async Task<ActionResult<IEnumerable<Bid>>> GetCarrierBids(int carrierId)
    {
        return await _context.Bids
            .Include(b => b.Ad)
            .Where(b => b.CarrierId == carrierId)
            .OrderByDescending(b => b.Id)
            .ToListAsync();
    }
    private async Task RunAutoBiddingEngine(int adId, int triggerBidId)
    {
        int iterations = 0;
        bool bidUpdated = true;

        while (bidUpdated && iterations < 20)
        {
            bidUpdated = false;
            iterations++;

            var ad = await _context.Ads
                .Include(a => a.Bids)
                    .ThenInclude(b => b.Carrier)
                .FirstOrDefaultAsync(a => a.Id == adId);

            if (ad == null || ad.Status != "Active" || ad.Bids.Count <= 1)
                break;

            var bids = ad.Bids.Where(b => b.Status == "Pending").ToList();
            if (!bids.Any())
                break;

            var lowestBid = bids.OrderBy(b => b.Amount).First();

            var targetBidAmount = lowestBid.Amount - 50m;
            if (targetBidAmount < ad.FloorPrice)
            {
                targetBidAmount = ad.FloorPrice;
            }

            var autoBidders = bids
                .Where(b => b.Id != lowestBid.Id && b.IsAutoBidEnabled && b.AutoBidMinLimit.HasValue && b.AutoBidMinLimit.Value <= targetBidAmount)
                .OrderBy(b => b.Amount)
                .FirstOrDefault();

            if (autoBidders != null && autoBidders.Amount > targetBidAmount)
            {
                autoBidders.Amount = targetBidAmount;
                autoBidders.Status = "Pending";
                
                var notification = new Notification
                {
                    UserId = autoBidders.CarrierId,
                    Title = "Otomatik Teklif Verildi",
                    Message = $"'{ad.Title}' ilanında rakip teklif üzerine sizin adınıza otomatik olarak {targetBidAmount:C2} tutarında yeni bir teklif yerleştirildi.",
                    CreatedAt = DateTime.UtcNow,
                    IsRead = false
                };
                _context.Notifications.Add(notification);

                await _context.SaveChangesAsync();
                bidUpdated = true;
            }
        }
    }
}

public class CreateBidDto
{
    public int AdId { get; set; }
    public int CarrierId { get; set; }
    public decimal Amount { get; set; }
    public bool IsAutoBidEnabled { get; set; }
    public decimal? AutoBidMinLimit { get; set; }
}
