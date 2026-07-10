using System;
using System.Text.Json.Serialization;

namespace backend.Models;

public class Transaction
{
    public int Id { get; set; }
    
    public int BidId { get; set; }
    
    public string AuthCode { get; set; } = string.Empty;
    
    public decimal AmountBlockedSender { get; set; }
    public decimal AmountBlockedCarrier { get; set; }
    
    public string Status { get; set; } = "Blocked"; // Blocked, Released, Captured, Cancelled
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? DeliveryImageUrl { get; set; }
    public bool IsVerifiedByAi { get; set; }
    
    // Navigation properties
    public virtual Bid? Bid { get; set; }
}
