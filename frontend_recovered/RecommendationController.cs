using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers;

[ApiController]
[Route("api/ads/{id}/recommendations")]
public class RecommendationController : ControllerBase
{
    private readonly AppDbContext _context;

    public RecommendationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ad>>> GetRecommendations(int id, [FromQuery] int? carrierLevel)
    {
        var sourceAd = await _context.Ads.FindAsync(id);
        if (sourceAd == null)
        {
            return NotFound(new { message = "Kaynak ilan bulunamadÄ±." });
        }

        var query = _context.Ads
            .Where(a => a.Id != id && a.Status == "Active");

        if (carrierLevel.HasValue)
        {
            // Only suggest ads the carrier has the level/permit to bid on
            query = query.Where(a => a.RequiredLevel <= carrierLevel.Value);
        }

        var allActiveAds = await query.ToListAsync();

        // Match and sort by relevance:
        // 1. Exact Return: StartLocation matches sourceEnd AND EndLocation matches sourceStart (Relevance: 2)
        // 2. Partial Return: StartLocation matches sourceEnd (Relevance: 1)
        var recommendations = allActiveAds
            .Select(a => new
            {
                Ad = a,
                Relevance = (a.StartLocation.Trim().Equals(sourceAd.EndLocation.Trim(), System.StringComparison.OrdinalIgnoreCase) && 
                             a.EndLocation.Trim().Equals(sourceAd.StartLocation.Trim(), System.StringComparison.OrdinalIgnoreCase)) 
                            ? 2 
                            : a.StartLocation.Trim().Equals(sourceAd.EndLocation.Trim(), System.StringComparison.OrdinalIgnoreCase) 
                            ? 1 
                            : 0
            })
            .Where(x => x.Relevance > 0)
            .OrderByDescending(x => x.Relevance)
            .ThenBy(x => x.Ad.FloorPrice)
            .Select(x => x.Ad)
            .ToList();

        return Ok(recommendations);
    }
}
