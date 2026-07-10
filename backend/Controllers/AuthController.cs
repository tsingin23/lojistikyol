using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using System.Security.Cryptography;
using System.Text;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/auth/users
    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users
            .Include(u => u.CarrierProfile)
            .ToListAsync();
    }

    // GET: api/auth/users/5
    [HttpGet("users/{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users
            .Include(u => u.CarrierProfile)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return NotFound(new { message = "Kullanıcı bulunamadı." });
        }

        return user;
    }

    // POST: api/auth/topup
    [HttpPost("topup")]
    public async Task<IActionResult> TopUp([FromBody] TopUpRequest request)
    {
        var user = await _context.Users.FindAsync(request.UserId);
        if (user == null)
        {
            return NotFound(new { message = "Kullanıcı bulunamadı." });
        }

        user.Balance += request.Amount;
        await _context.SaveChangesAsync();

        return Ok(new { message = $"Hesaba {request.Amount:C2} eklendi. Yeni bakiye: {user.Balance:C2}", balance = user.Balance });
    }

    // POST: api/auth/upgrade
    [HttpPost("upgrade")]
    public async Task<IActionResult> UpgradeCarrier([FromBody] UpgradeRequest request)
    {
        var user = await _context.Users
            .Include(u => u.CarrierProfile)
            .FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (user == null)
        {
            return NotFound(new { message = "Kullanıcı bulunamadı." });
        }

        if (user.UserType != "Carrier" || user.CarrierProfile == null)
        {
            return BadRequest(new { message = "Yalnızca taşıyıcı profili olan kullanıcılar seviye yükseltebilir." });
        }

        if (request.UpgradeType.ToLower() == "license")
        {
            user.UserLevel = 2;
            user.CarrierProfile.LicenseType = "A2/B Sınıfı (Doğrulanmış Kurye)";
            await _context.SaveChangesAsync();
            return Ok(new { message = "Kurye ehliyeti doğrulandı. Kullanıcı Level 2 seviyesine yükseltildi.", user });
        }
        else if (request.UpgradeType.ToLower() == "company")
        {
            user.UserLevel = 2;
            user.CarrierProfile.LicenseType = "Şahıs Şirketi (Doğrulandı)";
            user.CarrierProfile.InsuranceNo = request.InsuranceNo ?? "Vergi No: 9821038101";
            await _context.SaveChangesAsync();
            return Ok(new { message = "Şahıs şirketi vergi kaydı doğrulandı. Kullanıcı Level 2 seviyesine yükseltildi.", user });
        }
        else if (request.UpgradeType.ToLower() == "contract")
        {
            user.UserLevel = 2;
            user.CarrierProfile.LicenseType = "Bize Bağlı Çalışan (Sözleşmeli)";
            user.CarrierProfile.InsuranceNo = "Sözleşmeli Kurye Kaydı";
            await _context.SaveChangesAsync();
            return Ok(new { message = "Sözleşmeli kurye kaydı onaylandı. Kullanıcı Level 2 seviyesine yükseltildi.", user });
        }
        else if (request.UpgradeType.ToLower() == "insurance")
        {
            user.UserLevel = 3;
            user.CarrierProfile.InsuranceNo = request.InsuranceNo ?? "POL-MOCK-123456";
            user.CarrierProfile.LicenseType = "CE (Ağır Vasıta - Sigortalı)";
            await _context.SaveChangesAsync();
            return Ok(new { message = "Ticari kargo sigorta poliçesi doğrulandı. Kullanıcı Level 3 seviyesine yükseltildi.", user });
        }

        return BadRequest(new { message = "Geçersiz yükseltme türü. 'license', 'company', 'contract' veya 'insurance' giriniz." });
    }

    // GET: api/auth/fuelprice
    [HttpGet("fuelprice")]
    public IActionResult GetFuelPrice()
    {
        return Ok(new { fuelPrice = SystemConfig.CurrentFuelPrice });
    }

    // POST: api/auth/fuelprice
    [HttpPost("fuelprice")]
    public IActionResult SetFuelPrice([FromBody] FuelPriceRequest request)
    {
        if (request.Price <= 0)
        {
            return BadRequest(new { message = "Fiyat sıfırdan büyük olmalıdır." });
        }
        SystemConfig.CurrentFuelPrice = request.Price;
        return Ok(new { message = $"Akaryakıt litre fiyatı güncellendi: {SystemConfig.CurrentFuelPrice} TL", fuelPrice = SystemConfig.CurrentFuelPrice });
    }

    // POST: api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
        {
            return BadRequest(new { message = "Bu e-posta adresiyle zaten bir kullanıcı kayıtlı." });
        }

        var newUser = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = ComputeSha256Hash(request.Password),
            UserType = request.UserType,
            UserLevel = 1,
            Balance = request.UserType == "Sender" ? 150000m : 20000m,
            WelcomeBonusExpiry = request.UserType == "Carrier" ? DateTime.UtcNow.AddDays(7) : null,
            PeriodicBonusActive = request.UserType == "Carrier" ? true : false,
            City = string.IsNullOrWhiteSpace(request.City) ? "İstanbul" : request.City
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        if (newUser.UserType == "Carrier")
        {
            var cp = new CarrierProfile
            {
                UserId = newUser.Id,
                LicenseType = "B Sınıfı",
                Rating = 5.0,
                InsuranceNo = ""
            };
            _context.CarrierProfiles.Add(cp);
            await _context.SaveChangesAsync();
        }

        return Ok(newUser);
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var passwordHash = ComputeSha256Hash(request.Password);
        var user = await _context.Users
            .Include(u => u.CarrierProfile)
            .FirstOrDefaultAsync(u => u.Email == request.Email && u.PasswordHash == passwordHash);

        if (user == null)
        {
            return Unauthorized(new { message = "E-posta veya şifre hatalı." });
        }

        return Ok(user);
    }

    private static string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    // POST: api/auth/profile/update
    [HttpPost("profile/update")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
    {
        var user = await _context.Users
            .Include(u => u.CarrierProfile)
            .FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (user == null)
        {
            return NotFound(new { message = "Kullanıcı bulunamadı." });
        }

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            user.Name = request.Name;
        }

        if (!string.IsNullOrWhiteSpace(request.City))
        {
            user.City = request.City;
        }

        await _context.SaveChangesAsync();
        return Ok(user);
    }

    // GET: api/auth/fleet/drivers?parentId=...
    [HttpGet("fleet/drivers")]
    public async Task<IActionResult> GetFleetDrivers([FromQuery] int parentId)
    {
        var drivers = await _context.Users
            .Where(u => u.ParentFleetOwnerId == parentId)
            .ToListAsync();
        return Ok(drivers);
    }

    // POST: api/auth/fleet/add-driver
    [HttpPost("fleet/add-driver")]
    public async Task<IActionResult> AddFleetDriver([FromBody] AddDriverRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
        {
            return BadRequest(new { message = "Bu e-posta adresi zaten kullanımda." });
        }

        var driver = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = ComputeSha256Hash(request.Password),
            UserType = "Carrier",
            UserLevel = 1,
            ParentFleetOwnerId = request.ParentId,
            City = "İstanbul",
            Balance = 0
        };

        _context.Users.Add(driver);
        await _context.SaveChangesAsync();

        var profile = new CarrierProfile
        {
            UserId = driver.Id,
            LicenseType = "A2 Sınıfı (Moto Kurye)",
            Rating = 5.0
        };
        _context.CarrierProfiles.Add(profile);
        await _context.SaveChangesAsync();

        return Ok(driver);
    }

    // POST: api/auth/payout
    [HttpPost("payout")]
    public async Task<IActionResult> CreatePayout([FromBody] PayoutRequestPayload request)
    {
        var user = await _context.Users.FindAsync(request.UserId);
        if (user == null)
        {
            return NotFound(new { message = "Kullanıcı bulunamadı." });
        }

        if (user.Balance < request.Amount)
        {
            return BadRequest(new { message = "Yetersiz bakiye." });
        }

        user.Balance -= request.Amount;

        var payout = new PayoutRequest
        {
            UserId = request.UserId,
            Amount = request.Amount,
            BankName = request.BankName,
            BankAccountNumber = request.BankAccountNumber,
            Status = "Approved",
            CreatedAt = DateTime.UtcNow
        };

        _context.PayoutRequests.Add(payout);
        
        var notification = new Notification
        {
            UserId = request.UserId,
            Title = "QuickPay Ödemesi Çekildi",
            Message = $"{request.Amount:N2} TL tutarındaki bakiye {request.BankName} hesabınıza aktarıldı.",
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };
        _context.Notifications.Add(notification);

        await _context.SaveChangesAsync();
        return Ok(payout);
    }

    // GET: api/auth/payouts?userId=...
    [HttpGet("payouts")]
    public async Task<IActionResult> GetPayouts([FromQuery] int userId)
    {
        var payouts = await _context.PayoutRequests
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
        return Ok(payouts);
    }

    // GET: api/auth/notifications?userId=...
    [HttpGet("notifications")]
    public async Task<IActionResult> GetNotifications([FromQuery] int userId)
    {
        var notifications = await _context.Notifications
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
        return Ok(notifications);
    }

    // POST: api/auth/notifications/read?userId=...
    [HttpPost("notifications/read")]
    public async Task<IActionResult> MarkNotificationsRead([FromQuery] int userId)
    {
        var notifications = await _context.Notifications
            .Where(n => n.UserId == userId && !n.IsRead)
            .ToListAsync();

        foreach (var n in notifications)
        {
            n.IsRead = true;
        }

        await _context.SaveChangesAsync();
        return Ok(new { success = true });
    }
}

public class RegisterRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string UserType { get; set; } = "Carrier";
    public string City { get; set; } = "İstanbul";
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class TopUpRequest
{
    public int UserId { get; set; }
    public decimal Amount { get; set; }
}

public class UpgradeRequest
{
    public int UserId { get; set; }
    public string UpgradeType { get; set; } = string.Empty; // "license" or "insurance"
    public string? InsuranceNo { get; set; }
}

public class FuelPriceRequest
{
    public decimal Price { get; set; }
}

public class UpdateProfileRequest
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}

public class AddDriverRequest
{
    public int ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class PayoutRequestPayload
{
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public string BankName { get; set; } = string.Empty;
    public string BankAccountNumber { get; set; } = string.Empty;
}
