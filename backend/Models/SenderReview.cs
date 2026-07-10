using System;

namespace backend.Models;

public class SenderReview
{
    public int Id { get; set; }
    public int AdId { get; set; }
    public int SenderId { get; set; }
    public int CarrierId { get; set; }
    public int Score { get; set; } // 1 to 5
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual Ad? Ad { get; set; }
    public virtual User? Sender { get; set; }
    public virtual User? Carrier { get; set; }
}
