using System.Text.Json.Serialization;

namespace backend.Models;

public class Bid
{
    public int Id { get; set; }
    
    public int AdId { get; set; }
    public int CarrierId { get; set; }
    
    public decimal Amount { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected
    
    public bool IsAutoBidEnabled { get; set; } = false;
    public decimal? AutoBidMinLimit { get; set; }
    
    // Navigation properties
    [JsonIgnore]
    public virtual Ad? Ad { get; set; }
    
    public virtual User? Carrier { get; set; }
}
