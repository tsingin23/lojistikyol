using System;

namespace backend.Models;

public class PayoutRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string BankAccountNumber { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending"; // Pending, Approved
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property
    public virtual User? User { get; set; }
}
