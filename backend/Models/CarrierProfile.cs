using System.Text.Json.Serialization;

namespace backend.Models;

public class CarrierProfile
{
    public int Id { get; set; }
    
    // Foreign key to User
    public int UserId { get; set; }
    
    public string LicenseType { get; set; } = string.Empty;
    public double Rating { get; set; } = 5.0;
    public string InsuranceNo { get; set; } = string.Empty;

    // Navigation properties
    [JsonIgnore]
    public virtual User? User { get; set; }
}
