using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<CarrierProfile> CarrierProfiles { get; set; } = null!;
    public DbSet<Ad> Ads { get; set; } = null!;
    public DbSet<Bid> Bids { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<PayoutRequest> PayoutRequests { get; set; } = null!;
    public DbSet<SenderReview> SenderReviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1:1 relation between User and CarrierProfile
        modelBuilder.Entity<User>()
            .HasOne(u => u.CarrierProfile)
            .WithOne(cp => cp.User)
            .HasForeignKey<CarrierProfile>(cp => cp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Ad -> Sender relation
        modelBuilder.Entity<Ad>()
            .HasOne(a => a.Sender)
            .WithMany()
            .HasForeignKey(a => a.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Bid -> Ad relation
        modelBuilder.Entity<Bid>()
            .HasOne(b => b.Ad)
            .WithMany(a => a.Bids)
            .HasForeignKey(b => b.AdId)
            .OnDelete(DeleteBehavior.Cascade);

        // Bid -> Carrier relation
        modelBuilder.Entity<Bid>()
            .HasOne(b => b.Carrier)
            .WithMany()
            .HasForeignKey(b => b.CarrierId)
            .OnDelete(DeleteBehavior.Cascade);

        // Transaction -> Bid relation
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Bid)
            .WithOne()
            .HasForeignKey<Transaction>(t => t.BidId)
            .OnDelete(DeleteBehavior.Cascade);

        // SenderReview -> Sender & Carrier relation (Restrict cascade to prevent multiple cascade paths error)
        modelBuilder.Entity<SenderReview>()
            .HasOne(sr => sr.Sender)
            .WithMany()
            .HasForeignKey(sr => sr.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SenderReview>()
            .HasOne(sr => sr.Carrier)
            .WithMany()
            .HasForeignKey(sr => sr.CarrierId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Ahmet (Gönderici)", UserType = "Sender", UserLevel = 1, Balance = 300000m, Email = "ahmet@lojistikyol.com", PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", WelcomeBonusExpiry = null, PeriodicBonusActive = false, City = "İstanbul" },
            new User { Id = 2, Name = "Mehmet (Lvl 1 Taşıyıcı)", UserType = "Carrier", UserLevel = 1, Balance = 250000m, Email = "mehmet@lojistikyol.com", PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", WelcomeBonusExpiry = DateTime.Parse("2026-07-15T12:00:00Z"), PeriodicBonusActive = true, City = "İstanbul" },
            new User { Id = 3, Name = "Ali (Lvl 2 Taşıyıcı)", UserType = "Carrier", UserLevel = 2, Balance = 100000m, Email = "ali@lojistikyol.com", PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", WelcomeBonusExpiry = null, PeriodicBonusActive = true, City = "Ankara" },
            new User { Id = 4, Name = "Veli (Lvl 3 Taşıyıcı)", UserType = "Carrier", UserLevel = 3, Balance = 50000m, Email = "veli@lojistikyol.com", PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", WelcomeBonusExpiry = null, PeriodicBonusActive = false, City = "İzmir" }
        );

        // Seed CarrierProfiles
        modelBuilder.Entity<CarrierProfile>().HasData(
            new CarrierProfile { Id = 1, UserId = 2, LicenseType = "A2 Sınıfı (Moto Kurye)", Rating = 4.2, InsuranceNo = "" },
            new CarrierProfile { Id = 2, UserId = 3, LicenseType = "Şahıs Şirketi (Doğrulandı)", Rating = 4.7, InsuranceNo = "Vergi No: 198230281" },
            new CarrierProfile { Id = 3, UserId = 4, LicenseType = "CE (Ağır Vasıta - Sigortalı)", Rating = 4.9, InsuranceNo = "POL-9876543-XYZ" }
        );

        // Seed Ads (Dummy starting listings + 5 random ads for each of 81 Turkish cities)
        var ads = new List<Ad>
        {
            new Ad 
            { 
                Id = 1, 
                SenderId = 1, 
                Title = "İzmir - İstanbul Ev Eşyası Taşıma", 
                Description = "2+1 ev eşyası taşınacaktır. Dikkatli ve özenli taşıma gereklidir.",
                StartLocation = "İzmir",
                EndLocation = "İstanbul",
                DistanceKm = 480,
                FuelConsumptionRate = 12.0,
                CargoValue = 80000m,
                FloorPrice = 3360m,
                RequiredLevel = 1,
                Status = "Active",
                VerificationCode = "LY-1209",
                CargoImageUrl = "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80"
            },
            new Ad 
            { 
                Id = 2, 
                SenderId = 1, 
                Title = "Kocaeli - Ankara Paletli Demir Boru", 
                Description = "15 ton paletli demir boru sevkiyatı. Dorseli tır gereklidir.",
                StartLocation = "Kocaeli",
                EndLocation = "Ankara",
                DistanceKm = 350,
                FuelConsumptionRate = 32.0,
                CargoValue = 200000m,
                FloorPrice = 6240m,
                RequiredLevel = 2,
                Status = "Active",
                VerificationCode = "LY-8549",
                CargoImageUrl = "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80"
            },
            new Ad 
            { 
                Id = 3, 
                SenderId = 1, 
                Title = "İskenderun - Batman Kimyasal Hammadde", 
                Description = "Yüksek riskli kimyasal madde taşıması. ADR belgeli araç ve özel sigorta zorunludur.",
                StartLocation = "İskenderun",
                EndLocation = "Batman",
                DistanceKm = 420,
                FuelConsumptionRate = 35.0,
                CargoValue = 500000m,
                FloorPrice = 8115m,
                RequiredLevel = 3,
                Status = "Active",
                VerificationCode = "LY-4281",
                CargoImageUrl = "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80"
            },
            new Ad
            {
                Id = 101,
                SenderId = 1,
                Title = "İstanbul - İzmir Dönüş Sevkiyatı",
                Description = "İzmir'e geri dönecek araçlar için mobilya yükü.",
                StartLocation = "İstanbul",
                EndLocation = "İzmir",
                DistanceKm = 480,
                FuelConsumptionRate = 12.0,
                CargoValue = 60000m,
                FloorPrice = 3200m,
                RequiredLevel = 1,
                Status = "Active",
                VerificationCode = "LY-4091",
                CargoImageUrl = "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80"
            },
            new Ad
            {
                Id = 102,
                SenderId = 1,
                Title = "Ankara - Kocaeli Paletli Yük",
                Description = "Kocaeli yönüne dönecek tırlar için paletli rulo sac.",
                StartLocation = "Ankara",
                EndLocation = "Kocaeli",
                DistanceKm = 350,
                FuelConsumptionRate = 30.0,
                CargoValue = 120000m,
                FloorPrice = 5800m,
                RequiredLevel = 2,
                Status = "Active",
                VerificationCode = "LY-5120",
                CargoImageUrl = "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80"
            },
            new Ad
            {
                Id = 103,
                SenderId = 1,
                Title = "Batman - İskenderun Boş Dönüş Yükü",
                Description = "Liman yönüne dönecek tanker veya dorseler için ham petrol türevi.",
                StartLocation = "Batman",
                EndLocation = "İskenderun",
                DistanceKm = 420,
                FuelConsumptionRate = 35.0,
                CargoValue = 400000m,
                FloorPrice = 7900m,
                RequiredLevel = 3,
                Status = "Active",
                VerificationCode = "LY-6031",
                CargoImageUrl = "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80"
            },
            new Ad
            {
                Id = 104,
                SenderId = 1,
                Title = "İstanbul - Ankara Acil Gıda Sevkiyatı",
                Description = "Soğutmalı kasa (frigo) van veya kamyon için gıda paletleri.",
                StartLocation = "İstanbul",
                EndLocation = "Ankara",
                DistanceKm = 450,
                FuelConsumptionRate = 20.0,
                CargoValue = 150000m,
                FloorPrice = 4200m,
                RequiredLevel = 1,
                Status = "Active",
                VerificationCode = "LY-7102",
                CargoImageUrl = "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80"
            },
            new Ad
            {
                Id = 105,
                SenderId = 1,
                Title = "Ankara - İstanbul Ambalaj Malzemesi",
                Description = "İstanbul'a dönecek araçlar için hafif ama hacimli ambalaj kutuları.",
                StartLocation = "Ankara",
                EndLocation = "İstanbul",
                DistanceKm = 450,
                FuelConsumptionRate = 20.0,
                CargoValue = 170000m,
                FloorPrice = 4400m,
                RequiredLevel = 1,
                Status = "Active",
                VerificationCode = "LY-8192",
                CargoImageUrl = "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80"
            },
            new Ad
            {
                Id = 106,
                SenderId = 1,
                Title = "Bursa - İzmir Parça Koli Taşıma",
                Description = "İzmir yönüne boş dönecek van veya kamyonet için paletsiz koliler.",
                StartLocation = "Bursa",
                EndLocation = "İzmir",
                DistanceKm = 330,
                FuelConsumptionRate = 15.0,
                CargoValue = 50000m,
                FloorPrice = 2800m,
                RequiredLevel = 1,
                Status = "Active",
                VerificationCode = "LY-9104",
                CargoImageUrl = "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80"
            },
            new Ad
            {
                Id = 107,
                SenderId = 1,
                Title = "İzmir - Bursa Tekstil Hammaddesi",
                Description = "Bursa tekstil bölgesine gidecek iplik çuvalları.",
                StartLocation = "İzmir",
                EndLocation = "Bursa",
                DistanceKm = 330,
                FuelConsumptionRate = 15.0,
                CargoValue = 90000m,
                FloorPrice = 3000m,
                RequiredLevel = 1,
                Status = "Active",
                VerificationCode = "LY-1094",
                CargoImageUrl = "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80"
            },
            new Ad
            {
                Id = 108,
                SenderId = 1,
                Title = "İstanbul - Bursa Otomotiv Yedek Parça",
                Description = "Bursa fabrikasına acil yedek parça teslimatı.",
                StartLocation = "İstanbul",
                EndLocation = "Bursa",
                DistanceKm = 150,
                FuelConsumptionRate = 20.0,
                CargoValue = 130000m,
                FloorPrice = 2200m,
                RequiredLevel = 2,
                Status = "Active",
                VerificationCode = "LY-1102",
                CargoImageUrl = "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80"
            }
        };

        var allCitiesList = new string[] {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
            "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
            "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari",
            "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir",
            "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir",
            "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat",
            "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman",
            "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
        };

        var cargoTitlesList = new string[] {
            "Tekstil Ürünleri Sevkiyatı", "Paletli Gıda Kolileri", "Oto Yedek Parça Nakliyesi", "İnşaat Malzemeleri Götürme",
            "Mobilya ve Ev Eşyası Taşıma", "Beyaz Eşya Dağıtımı", "Plastik Hammadde Sevkiyatı", "Karton Kutu Ambalajları",
            "Tarım Gübresi ve Tohum", "Makine Teçhizat Parçaları"
        };

        var cargoDescriptionsList = new string[] {
            "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.",
            "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.",
            "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.",
            "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.",
            "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat."
        };

        var cargoImagesList = new string[] {
            "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80",
            "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80",
            "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80",
            "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80"
        };

        int adIdCounter = 1000;
        var rand = new Random(42);

        foreach (var startCity in allCitiesList)
        {
            for (int i = 0; i < 5; i++)
            {
                string endCity;
                do {
                    endCity = allCitiesList[rand.Next(allCitiesList.Length)];
                } while (endCity == startCity);

                int distance = rand.Next(100, 950);
                double fuelCons = rand.Next(10, 36); 
                decimal cargoVal = rand.Next(20, 501) * 1000m; 
                int reqLevel = rand.Next(1, 4);
                bool isInstant = (i % 3 == 0);
                double multiplier = (rand.Next(1, 10) > 7) ? 1.15 : 1.0;
                decimal baseFloor = Math.Round((distance * ((decimal)fuelCons / 100m) * 40m) + 500m + (cargoVal * 0.001m), 0);
                decimal finalFloor = Math.Round(baseFloor * (decimal)multiplier, 0);

                ads.Add(new Ad
                {
                    Id = adIdCounter++,
                    SenderId = 1,
                    Title = $"{startCity} - {endCity} {cargoTitlesList[rand.Next(cargoTitlesList.Length)]}",
                    Description = cargoDescriptionsList[rand.Next(cargoDescriptionsList.Length)],
                    StartLocation = startCity,
                    EndLocation = endCity,
                    DistanceKm = distance,
                    FuelConsumptionRate = fuelCons,
                    CargoValue = cargoVal,
                    FloorPrice = finalFloor,
                    RequiredLevel = reqLevel,
                    Status = "Active",
                    VerificationCode = $"LY-{rand.Next(1000, 10000)}",
                    CargoImageUrl = cargoImagesList[rand.Next(cargoImagesList.Length)],
                    IsInstantBook = isInstant,
                    InstantBookPrice = isInstant ? Math.Round(finalFloor * 1.1m, 0) : null,
                    WeatherDemandMultiplier = multiplier
                });
            }
        }

        modelBuilder.Entity<Ad>().HasData(ads);

        modelBuilder.Entity<Bid>().HasData(
            new Bid { Id = 101, AdId = 1, CarrierId = 2, Amount = 3500m, Status = "Pending" },
            new Bid { Id = 102, AdId = 2, CarrierId = 3, Amount = 6500m, Status = "Pending" },
            new Bid { Id = 103, AdId = 3, CarrierId = 4, Amount = 8300m, Status = "Pending" },
            new Bid { Id = 104, AdId = 101, CarrierId = 2, Amount = 3400m, Status = "Pending" },
            new Bid { Id = 105, AdId = 101, CarrierId = 3, Amount = 3300m, Status = "Pending" },
            new Bid { Id = 106, AdId = 104, CarrierId = 3, Amount = 4350m, Status = "Pending" },
            new Bid { Id = 107, AdId = 102, CarrierId = 4, Amount = 6000m, Status = "Pending" }
        );
    }
}
