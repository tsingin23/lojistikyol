using System.Text.Json.Serialization;

namespace backend.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserType { get; set; } = "Carrier"; // "Sender" or "Carrier"
    public int UserLevel { get; set; } = 1; // 1, 2, or 3 (For carriers)
    public decimal Balance { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime? WelcomeBonusExpiry { get; set; }
    public bool PeriodicBonusActive { get; set; }
    public string City { get; set; } = "İstanbul";
    public double SenderRating { get; set; } = 5.0;
    public int SenderRatingCount { get; set; } = 0;
    public int? ParentFleetOwnerId { get; set; }

    // Navigation property for Carrier Profile (1:1 relation)
    [JsonIgnore]
    public virtual CarrierProfile? CarrierProfile { get; set; }
}
