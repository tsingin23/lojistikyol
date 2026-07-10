using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddBonusFieldsAndSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PeriodicBonusActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "WelcomeBonusExpiry",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "Id", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "SenderId", "StartLocation", "Status", "Title", "VerificationCode" },
                values: new object[,]
                {
                    { 101, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 60000m, "İzmir'e geri dönecek araçlar için mobilya yükü.", 480.0, "İzmir", 3200m, 12.0, 1, 1, "İstanbul", "Active", "İstanbul - İzmir Dönüş Sevkiyatı", "LY-4091" },
                    { 102, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 120000m, "Kocaeli yönüne dönecek tırlar için paletli rulo sac.", 350.0, "Kocaeli", 5800m, 30.0, 2, 1, "Ankara", "Active", "Ankara - Kocaeli Paletli Yük", "LY-5120" },
                    { 103, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 400000m, "Liman yönüne dönecek tanker veya dorseler için ham petrol türevi.", 420.0, "İskenderun", 7900m, 35.0, 3, 1, "Batman", "Active", "Batman - İskenderun Boş Dönüş Yükü", "LY-6031" },
                    { 104, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 150000m, "Soğutmalı kasa (frigo) van veya kamyon için gıda paletleri.", 450.0, "Ankara", 4200m, 20.0, 1, 1, "İstanbul", "Active", "İstanbul - Ankara Acil Gıda Sevkiyatı", "LY-7102" },
                    { 105, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 170000m, "İstanbul'a dönecek araçlar için hafif ama hacimli ambalaj kutuları.", 450.0, "İstanbul", 4400m, 20.0, 1, 1, "Ankara", "Active", "Ankara - İstanbul Ambalaj Malzemesi", "LY-8192" },
                    { 106, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 50000m, "İzmir yönüne boş dönecek van veya kamyonet için paletsiz koliler.", 330.0, "İzmir", 2800m, 15.0, 1, 1, "Bursa", "Active", "Bursa - İzmir Parça Koli Taşıma", "LY-9104" },
                    { 107, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 90000m, "Bursa tekstil bölgesine gidecek iplik çuvalları.", 330.0, "Bursa", 3000m, 15.0, 1, 1, "İzmir", "Active", "İzmir - Bursa Tekstil Hammaddesi", "LY-1094" },
                    { 108, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 130000m, "Bursa fabrikasına acil yedek parça teslimatı.", 150.0, "Bursa", 2200m, 20.0, 2, 1, "İstanbul", "Active", "İstanbul - Bursa Otomotiv Yedek Parça", "LY-1102" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PeriodicBonusActive", "WelcomeBonusExpiry" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PeriodicBonusActive", "WelcomeBonusExpiry" },
                values: new object[] { true, new DateTime(2026, 7, 15, 15, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PeriodicBonusActive", "WelcomeBonusExpiry" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PeriodicBonusActive", "WelcomeBonusExpiry" },
                values: new object[] { false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DropColumn(
                name: "PeriodicBonusActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WelcomeBonusExpiry",
                table: "Users");
        }
    }
}
