using System.Text.Json.Serialization;

namespace backend.Models;

public class Ad
{
    public int Id { get; set; }
    
    public int SenderId { get; set; }
    
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public string StartLocation { get; set; } = string.Empty;
    public string EndLocation { get; set; } = string.Empty;
    
    public double DistanceKm { get; set; }
    
    // Fuel consumption in Liters per 100km (e.g. 30)
    public double FuelConsumptionRate { get; set; } = 30.0;
    
    public decimal CargoValue { get; set; }
    public decimal FloorPrice { get; set; }
    
    public int RequiredLevel { get; set; } = 1; // 1, 2, 3
    
    public string Status { get; set; } = "Active"; // Active, BiddingClosed, InTransit, Completed
    public string? CargoImageUrl { get; set; }
    public string VerificationCode { get; set; } = string.Empty;

    public bool IsInstantBook { get; set; } = false;
    public decimal? InstantBookPrice { get; set; }
    public double WeatherDemandMultiplier { get; set; } = 1.0;
    
    public string? WaybillUrl { get; set; }
    public string? WaybillOcrText { get; set; }
    public int? AssignedDriverId { get; set; }
    public DateTime AuctionEndsAt { get; set; } = DateTime.UtcNow.AddHours(24);
    
    // Navigation properties
    [JsonIgnore]
    public virtual User? Sender { get; set; }
    
    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
}
