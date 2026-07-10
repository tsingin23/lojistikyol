using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UberFreightUpgrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentFleetOwnerId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SenderRating",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SenderRatingCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AssignedDriverId",
                table: "Ads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InstantBookPrice",
                table: "Ads",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInstantBook",
                table: "Ads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WaybillOcrText",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WaybillUrl",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WeatherDemandMultiplier",
                table: "Ads",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayoutRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayoutRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SenderReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    CarrierId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SenderReviews_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SenderReviews_Users_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SenderReviews_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "AssignedDriverId", "InstantBookPrice", "IsInstantBook", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, null, false, null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1000,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "Description", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 2101m, true, "Adana - Samsun Karton Kutu Ambalajları", "LY-2562", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 174000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 318.0, "Denizli", 3600m, 23.0, null, false, 2, "Adana - Denizli Beyaz Eşya Dağıtımı", "LY-8327", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 359000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 229.0, "Mersin", 1958m, 12.0, null, false, 3, "Adana - Mersin Tekstil Ürünleri Sevkiyatı", "LY-2329", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 39000m, 538.0, "Sinop", 3552m, 14.0, 3907m, true, 1, "Adana - Sinop Tarım Gübresi ve Tohum", "LY-5821", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 32000m, 426.0, "Trabzon", 3159m, 13.0, null, false, 1, "Adana - Trabzon Plastik Hammadde Sevkiyatı", "LY-3249", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 41000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 650.0, "Erzincan", 3921m, 13.0, 4313m, true, 2, "Adıyaman - Erzincan Tekstil Ürünleri Sevkiyatı", "LY-7359", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 148000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 111.0, "Çankırı", 1492m, 19.0, null, false, 1, "Adıyaman - Çankırı Tekstil Ürünleri Sevkiyatı", "LY-1108", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 24000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 536.0, "Kars", 5241m, 22.0, null, false, 3, "Adıyaman - Kars Tekstil Ürünleri Sevkiyatı", "LY-6887", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 200000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 889.0, "Bartın", 8168m, 21.0, 8985m, true, 2, "Adıyaman - Bartın İnşaat Malzemeleri Götürme", "LY-4932", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1009,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 456000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 440.0, "Malatya", 3948m, 17.0, null, false, 2, "Adıyaman - Malatya Tekstil Ürünleri Sevkiyatı", "LY-9619", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 237000m, 238.0, "Sivas", 1879m, 12.0, 2067m, true, 1, "Afyonkarahisar - Sivas Paletli Gıda Kolileri", "LY-2940", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1011,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 343000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 938.0, "Konya", 11724m, 29.0, null, false, 3, "Afyonkarahisar - Konya Beyaz Eşya Dağıtımı", "LY-6857", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 125000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 889.0, "Giresun", 4181m, 10.0, null, false, 1, "Afyonkarahisar - Giresun Oto Yedek Parça Nakliyesi", "LY-4799", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1013,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 174000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 203.0, 1648m, 12.0, 1813m, true, 1, "Afyonkarahisar - Düzce Tarım Gübresi ve Tohum", "LY-1378", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 426000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 302.0, "Şırnak", 5033m, 34.0, null, false, 1, "Afyonkarahisar - Şırnak Plastik Hammadde Sevkiyatı", "LY-2730", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 468000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 125.0, "Burdur", 2033m, 16.0, 2236m, true, "Ağrı - Burdur Paletli Gıda Kolileri", "LY-2680", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 78000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 572.0, "Kahramanmaraş", 6984m, 28.0, null, false, 2, "Ağrı - Kahramanmaraş Tarım Gübresi ve Tohum", "LY-4133", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 409000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 561.0, "Kayseri", 8539m, 34.0, null, false, 1, "Ağrı - Kayseri Tekstil Ürünleri Sevkiyatı", "LY-9462", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1018,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 80000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 602.0, "Mersin", 6205m, 20.0, 6826m, true, "Ağrı - Mersin Tarım Gübresi ve Tohum", "LY-4004", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 379000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 901.0, "Nevşehir", 12051m, null, false, "Ağrı - Nevşehir Beyaz Eşya Dağıtımı", "LY-3223", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 129000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 261.0, "Sakarya", 2404m, 17.0, 2644m, true, "Amasya - Sakarya Tekstil Ürünleri Sevkiyatı", "LY-8246", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 244000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 910.0, "Uşak", 15088m, null, false, "Amasya - Uşak Paletli Gıda Kolileri", "LY-2901", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 407000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 702.0, "Kocaeli", 4277m, 12.0, null, false, 2, "Amasya - Kocaeli Karton Kutu Ambalajları", "LY-5768", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 45000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 268.0, "Muğla", 4190m, 34.0, 4609m, true, 1, "Amasya - Muğla İnşaat Malzemeleri Götürme", "LY-3621", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1024,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 238000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 499.0, "Batman", 4530m, 19.0, null, false, 3, "Amasya - Batman Makine Teçhizat Parçaları", "LY-8708", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1025,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 314000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 897.0, "Burdur", 11252m, 25.0, 12377m, true, 2, "Ankara - Burdur Tekstil Ürünleri Sevkiyatı", "LY-8925", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1026,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 27000m, 849.0, "Ardahan", 11734m, 33.0, null, false, "Ankara - Ardahan Tekstil Ürünleri Sevkiyatı", "LY-4698", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1027,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 472000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 936.0, "Sakarya", 7337m, 17.0, null, false, 3, "Ankara - Sakarya İnşaat Malzemeleri Götürme", "LY-1383", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1028,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 125000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 410.0, "Kütahya", 3577m, 18.0, 3935m, true, 2, "Ankara - Kütahya Plastik Hammadde Sevkiyatı", "LY-6986", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1029,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 490000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 816.0, "Bingöl", 6539m, 17.0, null, false, "Ankara - Bingöl Beyaz Eşya Dağıtımı", "LY-2398", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1030,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 106000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 192.0, "Rize", 3217m, 34.0, 3539m, true, 2, "Antalya - Rize Plastik Hammadde Sevkiyatı", "LY-8745", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1031,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 113000m, 458.0, "Nevşehir", 4460m, 21.0, null, false, 3, "Antalya - Nevşehir Beyaz Eşya Dağıtımı", "LY-4702", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1032,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 169000m, 692.0, "Kilis", 5544m, 15.0, null, false, 2, "Antalya - Kilis Plastik Hammadde Sevkiyatı", "LY-6303", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1033,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 433000m, 941.0, "Kastamonu", 9590m, 23.0, 10549m, true, "Antalya - Kastamonu Mobilya ve Ev Eşyası Taşıma", "LY-6064", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1034,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 168000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 910.0, "Adana", 8312m, 21.0, null, false, "Antalya - Adana Mobilya ve Ev Eşyası Taşıma", "LY-2695", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1035,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 260000m, 871.0, "Kayseri", 14497m, 34.0, 15947m, true, 1, "Artvin - Kayseri Tarım Gübresi ve Tohum", "LY-6758", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1036,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 72000m, 375.0, "Kocaeli", 2222m, 11.0, null, false, 3, "Artvin - Kocaeli Makine Teçhizat Parçaları", "LY-2385", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1037,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 22000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 417.0, "Bilecik", 2524m, 12.0, null, false, 2, "Artvin - Bilecik Oto Yedek Parça Nakliyesi", "LY-8444", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1038,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 401000m, 608.0, "Mersin", 4063m, 13.0, 4469m, true, 1, "Artvin - Mersin Tekstil Ürünleri Sevkiyatı", "LY-6859", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1039,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 366000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 768.0, "Kütahya", 7932m, null, false, "Artvin - Kütahya Tarım Gübresi ve Tohum", "LY-4638", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1040,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 410000m, 818.0, "Van", 12035m, 34.0, 13238m, true, 2, "Aydın - Van Karton Kutu Ambalajları", "LY-8631", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1041,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 411000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 921.0, "Sivas", 13757m, 30.0, null, false, 2, "Aydın - Sivas Paletli Gıda Kolileri", "LY-8385", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1042,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 48000m, 880.0, "Mardin", 12164m, 33.0, null, false, 3, "Aydın - Mardin Tarım Gübresi ve Tohum", "LY-1934", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1043,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 485000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 850.0, "Bilecik", 8805m, 23.0, 9686m, true, 1, "Aydın - Bilecik Plastik Hammadde Sevkiyatı", "LY-2166", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1044,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 243000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 198.0, "Trabzon", 1773m, 13.0, null, false, 2, "Aydın - Trabzon Makine Teçhizat Parçaları", "LY-3484", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1045,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 41000m, 626.0, "Kırklareli", 7245m, 23.0, 7970m, true, "Balıkesir - Kırklareli Makine Teçhizat Parçaları", "LY-9679", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1046,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 439000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 446.0, "Denizli", 7439m, 31.0, null, false, 1, "Balıkesir - Denizli Mobilya ve Ev Eşyası Taşıma", "LY-8050", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1047,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 318000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 846.0, "Diyarbakır", 5217m, 13.0, null, false, "Balıkesir - Diyarbakır Karton Kutu Ambalajları", "LY-7098", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1048,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 72000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 219.0, "Hakkari", 1623m, 12.0, 1785m, true, "Balıkesir - Hakkari İnşaat Malzemeleri Götürme", "LY-7165", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1049,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 411000m, 758.0, "Niğde", 6672m, null, false, "Balıkesir - Niğde Oto Yedek Parça Nakliyesi", "LY-4685", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1050,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 205000m, 221.0, "Aydın", 3711m, 34.0, 4082m, true, "Bilecik - Aydın Mobilya ve Ev Eşyası Taşıma", "LY-4871", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1051,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 347000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 502.0, "Balıkesir", 3859m, 15.0, null, false, 3, "Bilecik - Balıkesir Oto Yedek Parça Nakliyesi", "LY-4402", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1052,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 322000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 937.0, "Kırklareli", 5694m, 13.0, null, false, 1, "Bilecik - Kırklareli Beyaz Eşya Dağıtımı", "LY-6952", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1053,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 79000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 511.0, "Burdur", 2827m, 11.0, 3110m, true, "Bilecik - Burdur Oto Yedek Parça Nakliyesi", "LY-4285", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1054,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 434000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 475.0, "Afyonkarahisar", 2834m, 10.0, null, false, 1, "Bilecik - Afyonkarahisar Beyaz Eşya Dağıtımı", "LY-8797", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1055,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 437000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 579.0, "Ağrı", 8580m, 33.0, 9438m, true, "Bingöl - Ağrı Makine Teçhizat Parçaları", "LY-2112", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1056,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 94000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 228.0, "Antalya", 2053m, 16.0, null, false, 2, "Bingöl - Antalya Mobilya ve Ev Eşyası Taşıma", "LY-5581", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1057,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 254000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 582.0, "Batman", 5177m, 19.0, null, false, "Bingöl - Batman Makine Teçhizat Parçaları", "LY-6283", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1058,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 404000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 825.0, "Bartın", 7834m, 21.0, 8617m, true, "Bingöl - Bartın Beyaz Eşya Dağıtımı", "LY-1425", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1059,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 66000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 879.0, "Denizli", 10759m, 25.0, null, false, 3, "Bingöl - Denizli Paletli Gıda Kolileri", "LY-2911", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1060,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 88000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 517.0, "Tekirdağ", 3483m, 14.0, 3831m, true, 3, "Bitlis - Tekirdağ Oto Yedek Parça Nakliyesi", "LY-4249", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1061,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 27000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 693.0, "Burdur", 8289m, 28.0, null, false, 2, "Bitlis - Burdur Plastik Hammadde Sevkiyatı", "LY-9310", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1062,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 241000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 314.0, "Ağrı", 2297m, 10.0, null, false, 2, "Bitlis - Ağrı Makine Teçhizat Parçaları", "LY-7074", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1063,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 102000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 154.0, "Bayburt", 1341m, 12.0, 1475m, true, "Bitlis - Bayburt Plastik Hammadde Sevkiyatı", "LY-8415", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1064,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 23000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 240.0, "Mersin", 3499m, 31.0, null, false, "Bitlis - Mersin Oto Yedek Parça Nakliyesi", "LY-7573", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1065,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 104000m, 732.0, "Bursa", 10559m, 34.0, 11615m, true, 2, "Bolu - Bursa Mobilya ve Ev Eşyası Taşıma", "LY-6890", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1066,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 375000m, 904.0, "Konya", 11361m, 29.0, null, false, 1, "Bolu - Konya Plastik Hammadde Sevkiyatı", "LY-6689", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1067,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 100000m, 417.0, "Malatya", 5678m, 26.0, null, false, "Bolu - Malatya Mobilya ve Ev Eşyası Taşıma", "LY-6318", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1068,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 62000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 418.0, "Tunceli", 4408m, 23.0, 4849m, true, "Bolu - Tunceli Paletli Gıda Kolileri", "LY-8216", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1069,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 412000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 941.0, "Karabük", 11075m, 27.0, null, false, 1, "Bolu - Karabük Mobilya ve Ev Eşyası Taşıma", "LY-8280", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1070,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 394000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 668.0, "Ardahan", 11476m, 34.0, 12624m, true, 1, "Burdur - Ardahan Paletli Gıda Kolileri", "LY-5871", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1071,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 358000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 466.0, "Afyonkarahisar", 3095m, 12.0, null, false, 1, "Burdur - Afyonkarahisar Mobilya ve Ev Eşyası Taşıma", "LY-3792", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1072,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 367000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 707.0, "Adana", 9068m, null, false, 3, "Burdur - Adana Karton Kutu Ambalajları", "LY-9334", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1073,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 421000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 405.0, "Kastamonu", 3351m, 15.0, 3686m, true, 1, "Burdur - Kastamonu Mobilya ve Ev Eşyası Taşıma", "LY-1316", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1074,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 170000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 364.0, "Osmaniye", 3436m, 19.0, null, false, 3, "Burdur - Osmaniye Tarım Gübresi ve Tohum", "LY-6115", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1075,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 361000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 756.0, "Ağrı", 9631m, 29.0, 10594m, true, "Bursa - Ağrı Makine Teçhizat Parçaları", "LY-8040", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1076,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 195000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 363.0, 5341m, 32.0, null, false, 1, "Bursa - Aydın Oto Yedek Parça Nakliyesi", "LY-7027", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1077,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 357000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 664.0, "Tekirdağ", 7763m, 26.0, null, false, 1, "Bursa - Tekirdağ İnşaat Malzemeleri Götürme", "LY-8646", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1078,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 415000m, 737.0, "Sakarya", 5632m, 16.0, 6195m, true, 1, "Bursa - Sakarya Beyaz Eşya Dağıtımı", "LY-1802", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1079,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 273000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 257.0, "Bitlis", 4371m, 35.0, null, false, "Bursa - Bitlis Mobilya ve Ev Eşyası Taşıma", "LY-3490", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1080,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 218000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 613.0, "Eskişehir", 4886m, 17.0, 5375m, true, "Çanakkale - Eskişehir Paletli Gıda Kolileri", "LY-6341", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1081,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 169000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 531.0, "Karaman", 4705m, 19.0, null, false, 3, "Çanakkale - Karaman Tekstil Ürünleri Sevkiyatı", "LY-3075", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1082,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 424000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 701.0, "Antalya", 4850m, 14.0, null, false, 3, "Çanakkale - Antalya Plastik Hammadde Sevkiyatı", "LY-2851", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1083,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 334000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 400.0, "Diyarbakır", 2914m, 13.0, 3205m, true, 1, "Çanakkale - Diyarbakır Mobilya ve Ev Eşyası Taşıma", "LY-4921", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1084,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 40000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 549.0, "Kütahya", 7787m, 33.0, null, false, 3, "Çanakkale - Kütahya Tarım Gübresi ve Tohum", "LY-7158", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1085,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 464000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 441.0, "Muş", 6080m, 29.0, 6688m, true, 1, "Çankırı - Muş Mobilya ve Ev Eşyası Taşıma", "LY-4753", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1086,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 90000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 154.0, "Siirt", 2561m, null, false, 3, "Çankırı - Siirt İnşaat Malzemeleri Götürme", "LY-2336", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1087,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 247000m, 305.0, "Bartın", 3797m, 25.0, null, false, "Çankırı - Bartın Karton Kutu Ambalajları", "LY-8765", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1088,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 53000m, 130.0, "Tokat", 1832m, 20.0, 2015m, true, 3, "Çankırı - Tokat Beyaz Eşya Dağıtımı", "LY-5883", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1089,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 300000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 108.0, "Rize", 1664m, 20.0, null, false, "Çankırı - Rize Plastik Hammadde Sevkiyatı", "LY-3255", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1090,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 454000m, 159.0, "Erzincan", 2417m, 23.0, 2659m, true, "Çorum - Erzincan Karton Kutu Ambalajları", "LY-1889", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1091,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 54000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 332.0, "Yozgat", 3874m, 25.0, null, false, 1, "Çorum - Yozgat Plastik Hammadde Sevkiyatı", "LY-3702", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1092,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 303000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 216.0, "Bartın", 2315m, 14.0, null, false, "Çorum - Bartın Tarım Gübresi ve Tohum", "LY-4567", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1093,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 204000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 123.0, "Batman", 2328m, 33.0, 2561m, true, "Çorum - Batman Beyaz Eşya Dağıtımı", "LY-8515", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1094,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 494000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 348.0, "Amasya", 2804m, 13.0, null, false, "Çorum - Amasya Mobilya ve Ev Eşyası Taşıma", "LY-5193", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1095,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 169000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 849.0, "Yozgat", 8140m, 22.0, 8954m, true, 2, "Denizli - Yozgat Tarım Gübresi ve Tohum", "LY-7897", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1096,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 374000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 752.0, "Kütahya", 12420m, 33.0, null, false, "Denizli - Kütahya İnşaat Malzemeleri Götürme", "LY-1174", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1097,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 411000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 231.0, "Balıkesir", 4053m, 34.0, null, false, 3, "Denizli - Balıkesir Tekstil Ürünleri Sevkiyatı", "LY-8570", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1098,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 484000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 519.0, "Kırklareli", 5966m, 24.0, 6563m, true, "Denizli - Kırklareli Beyaz Eşya Dağıtımı", "LY-8353", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1099,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 256000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 613.0, "Uşak", 7867m, 29.0, null, false, "Denizli - Uşak İnşaat Malzemeleri Götürme", "LY-3832", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1100,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 25000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 286.0, "Düzce", 2584m, 18.0, 2842m, true, 1, "Diyarbakır - Düzce Makine Teçhizat Parçaları", "LY-4876", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1101,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 20000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 679.0, "Bingöl", 3779m, 12.0, null, false, 3, "Diyarbakır - Bingöl Oto Yedek Parça Nakliyesi", "LY-2638", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1102,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 77000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 778.0, "Çankırı", 6801m, 20.0, null, false, 3, "Diyarbakır - Çankırı Mobilya ve Ev Eşyası Taşıma", "LY-8684", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1103,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 440000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 630.0, "Çorum", 9256m, 33.0, 10182m, true, 3, "Diyarbakır - Çorum Paletli Gıda Kolileri", "LY-6904", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1104,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 438000m, 871.0, "Ankara", 5467m, 13.0, null, false, 3, "Diyarbakır - Ankara Beyaz Eşya Dağıtımı", "LY-6564", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1105,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 330000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 492.0, "Antalya", 3782m, 15.0, 4160m, true, "Edirne - Antalya Tarım Gübresi ve Tohum", "LY-4027", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1106,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 425000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 497.0, "Çorum", 6889m, 30.0, null, false, 3, "Edirne - Çorum Karton Kutu Ambalajları", "LY-3010", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1107,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 153000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 662.0, "Karaman", 5155m, 17.0, null, false, "Edirne - Karaman Plastik Hammadde Sevkiyatı", "LY-4280", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1108,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 466000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 678.0, "Düzce", 9373m, 31.0, 10310m, true, 2, "Edirne - Düzce Mobilya ve Ev Eşyası Taşıma", "LY-2160", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1109,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 434000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 930.0, "İstanbul", 6514m, 15.0, null, false, 3, "Edirne - İstanbul Paletli Gıda Kolileri", "LY-2330", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1110,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 498000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 372.0, "Erzurum", 4420m, 23.0, 4862m, true, 1, "Elazığ - Erzurum Paletli Gıda Kolileri", "LY-1447", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1111,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 386000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 369.0, "Manisa", 5462m, 31.0, null, false, 3, "Elazığ - Manisa Plastik Hammadde Sevkiyatı", "LY-4035", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1112,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 326000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 570.0, "Aydın", 3834m, 11.0, null, false, 1, "Elazığ - Aydın Mobilya ve Ev Eşyası Taşıma", "LY-6475", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1113,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 80000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 387.0, "Çanakkale", 3521m, 19.0, 3873m, true, "Elazığ - Çanakkale Paletli Gıda Kolileri", "LY-8762", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1114,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 355000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 518.0, "Mardin", 3756m, 14.0, null, false, 1, "Elazığ - Mardin Paletli Gıda Kolileri", "LY-1532", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1115,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 111000m, 301.0, "Osmaniye", 4825m, 35.0, 5308m, true, 1, "Erzincan - Osmaniye Oto Yedek Parça Nakliyesi", "LY-8090", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1116,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 49000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 756.0, "Kilis", 5992m, 18.0, null, false, "Erzincan - Kilis Makine Teçhizat Parçaları", "LY-5414", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1117,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 141000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 759.0, "Isparta", 3677m, 10.0, null, false, 2, "Erzincan - Isparta İnşaat Malzemeleri Götürme", "LY-6356", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1118,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 256000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 100.0, "Tokat", 1743m, 19.0, 1917m, true, "Erzincan - Tokat İnşaat Malzemeleri Götürme", "LY-9894", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1119,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 346000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 347.0, "İzmir", 2729m, 11.0, null, false, 1, "Erzincan - İzmir Paletli Gıda Kolileri", "LY-5241", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1120,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 465000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 471.0, "Bitlis", 7371m, 34.0, 8108m, true, 3, "Erzurum - Bitlis Oto Yedek Parça Nakliyesi", "LY-8270", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1121,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 347000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 835.0, "Isparta", 7504m, 17.0, null, false, "Erzurum - Isparta Mobilya ve Ev Eşyası Taşıma", "LY-1476", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1122,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 487000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 753.0, "Aksaray", 9421m, 28.0, null, false, 3, "Erzurum - Aksaray Karton Kutu Ambalajları", "LY-2241", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1123,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 384000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 296.0, "Kars", 4791m, 33.0, 5270m, true, "Erzurum - Kars Tekstil Ürünleri Sevkiyatı", "LY-7851", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1124,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 239000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 651.0, "Tokat", 5687m, 19.0, null, false, 1, "Erzurum - Tokat Tekstil Ürünleri Sevkiyatı", "LY-3098", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1125,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 122000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 394.0, "Isparta", 2513m, 12.0, 2764m, true, 3, "Eskişehir - Isparta Karton Kutu Ambalajları", "LY-2976", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1126,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 131000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 864.0, "Kırşehir", 9271m, 25.0, null, false, 1, "Eskişehir - Kırşehir Makine Teçhizat Parçaları", "LY-7552", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1127,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 141000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 941.0, "Iğdır", 4781m, null, false, 2, "Eskişehir - Iğdır İnşaat Malzemeleri Götürme", "LY-8573", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1128,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 498000m, 385.0, "Antalya", 2846m, 12.0, 3131m, true, "Eskişehir - Antalya Paletli Gıda Kolileri", "LY-7821", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1129,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 80000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 144.0, "Muğla", 1661m, 15.0, null, false, 1, "Eskişehir - Muğla Tekstil Ürünleri Sevkiyatı", "LY-4245", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1130,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 63000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 514.0, "Muş", 5909m, 26.0, 6500m, true, 1, "Gaziantep - Muş Oto Yedek Parça Nakliyesi", "LY-7254", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1131,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 55000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 488.0, "Osmaniye", 3093m, 13.0, null, false, "Gaziantep - Osmaniye Tarım Gübresi ve Tohum", "LY-1364", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1132,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 96000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 324.0, "Adana", 5007m, 29.0, null, false, 2, "Gaziantep - Adana Karton Kutu Ambalajları", "LY-9470", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1133,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 438000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 318.0, "Balıkesir", 5136m, 33.0, 5650m, true, 2, "Gaziantep - Balıkesir Plastik Hammadde Sevkiyatı", "LY-8017", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1134,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 475000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 377.0, "Yozgat", 6253m, 35.0, null, false, 2, "Gaziantep - Yozgat Makine Teçhizat Parçaları", "LY-6158", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1135,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 189000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 508.0, "Afyonkarahisar", 3127m, 12.0, 3440m, true, "Giresun - Afyonkarahisar Karton Kutu Ambalajları", "LY-5759", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1136,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 27000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 389.0, "Nevşehir", 5662m, 33.0, null, false, 3, "Giresun - Nevşehir Beyaz Eşya Dağıtımı", "LY-5765", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1137,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 138000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 776.0, "Kayseri", 9950m, 30.0, null, false, 1, "Giresun - Kayseri Oto Yedek Parça Nakliyesi", "LY-6174", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1138,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 397000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 649.0, "Kilis", 5829m, 6412m, true, 2, "Giresun - Kilis Paletli Gıda Kolileri", "LY-9151", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1139,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 233000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 263.0, "Kırıkkale", 3047m, 22.0, null, false, "Giresun - Kırıkkale Mobilya ve Ev Eşyası Taşıma", "LY-3334", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1140,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 316000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 634.0, "Mardin", 7156m, 25.0, 7872m, true, 3, "Gümüşhane - Mardin Plastik Hammadde Sevkiyatı", "LY-2358", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1141,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 65000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 869.0, 13841m, 33.0, null, false, "Gümüşhane - Ankara Makine Teçhizat Parçaları", "LY-4365", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1142,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 175000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 107.0, "Mardin", 1488m, 19.0, null, false, "Gümüşhane - Mardin İnşaat Malzemeleri Götürme", "LY-1602", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1143,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 366000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 339.0, "Denizli", 4120m, 24.0, 4532m, true, 3, "Gümüşhane - Denizli Tekstil Ürünleri Sevkiyatı", "LY-1883", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1144,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 318000m, 357.0, 4225m, 20.0, null, false, "LY-1730", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1145,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 122000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 389.0, "Kocaeli", 4512m, 25.0, 4963m, true, "Hakkari - Kocaeli Oto Yedek Parça Nakliyesi", "LY-5820", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1146,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 220000m, 362.0, "Ardahan", 5824m, 30.0, null, false, "Hakkari - Ardahan İnşaat Malzemeleri Götürme", "LY-3056", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1147,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 487000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 289.0, "Iğdır", 2143m, 10.0, null, false, "Hakkari - Iğdır Plastik Hammadde Sevkiyatı", "LY-2726", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1148,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 431000m, 893.0, "Adana", 8053m, 17.0, 8858m, true, 1, "Hakkari - Adana Plastik Hammadde Sevkiyatı", "LY-4963", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1149,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 350000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 745.0, "Artvin", 5320m, 15.0, null, false, "Hakkari - Artvin Beyaz Eşya Dağıtımı", "LY-6188", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1150,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 50000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 166.0, "Niğde", 1480m, 14.0, 1628m, true, 1, "Hatay - Niğde İnşaat Malzemeleri Götürme", "LY-2233", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1151,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 223000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 531.0, "Yalova", 3763m, 12.0, null, false, "Hatay - Yalova Tekstil Ürünleri Sevkiyatı", "LY-2608", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1152,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 464000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 101.0, "Balıkesir", 2136m, 29.0, null, false, "Hatay - Balıkesir Tekstil Ürünleri Sevkiyatı", "LY-5454", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1153,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 429000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 636.0, "Trabzon", 5165m, 14.0, 5682m, true, "Hatay - Trabzon Karton Kutu Ambalajları", "LY-6139", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1154,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 226000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 131.0, "Kahramanmaraş", 1512m, null, false, "Hatay - Kahramanmaraş Plastik Hammadde Sevkiyatı", "LY-3500", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1155,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 227000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 597.0, "Ordu", 7891m, 30.0, 8680m, true, 1, "Isparta - Ordu İnşaat Malzemeleri Götürme", "LY-2206", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1156,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 367000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 119.0, "Edirne", 1486m, 13.0, null, false, 1, "Isparta - Edirne İnşaat Malzemeleri Götürme", "LY-9391", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1157,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 121000m, 786.0, "Çankırı", 6595m, null, false, "Isparta - Çankırı Karton Kutu Ambalajları", "LY-6110", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1158,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 23000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 284.0, "Kocaeli", 1659m, 10.0, 1825m, true, "Isparta - Kocaeli Tarım Gübresi ve Tohum", "LY-6661", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1159,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 238000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 564.0, "Muş", 3445m, 12.0, null, false, 3, "Isparta - Muş Tarım Gübresi ve Tohum", "LY-2527", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1160,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 400000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 466.0, "Denizli", 7895m, 32.0, 8684m, true, 1, "Mersin - Denizli Oto Yedek Parça Nakliyesi", "LY-8627", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1161,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 397000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 945.0, "Zonguldak", 11103m, 27.0, null, false, 2, "Mersin - Zonguldak Makine Teçhizat Parçaları", "LY-9467", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1162,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 49000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 604.0, "Kırşehir", 6589m, 25.0, null, false, "Mersin - Kırşehir Karton Kutu Ambalajları", "LY-5578", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1163,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 275000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 362.0, "Bursa", 2802m, 14.0, 3082m, true, "Mersin - Bursa İnşaat Malzemeleri Götürme", "LY-7570", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1164,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 255000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 304.0, "Yalova", 4768m, 33.0, null, false, 1, "Mersin - Yalova Tarım Gübresi ve Tohum", "LY-8510", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1165,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 57000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 746.0, "Manisa", 7719m, 24.0, 8491m, true, 2, "İstanbul - Manisa Tarım Gübresi ve Tohum", "LY-9132", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1166,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 405000m, 371.0, "Aydın", 2686m, 12.0, null, false, 3, "İstanbul - Aydın Tarım Gübresi ve Tohum", "LY-7105", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1167,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 494000m, 729.0, "Siirt", 6826m, 20.0, null, false, 1, "İstanbul - Siirt Plastik Hammadde Sevkiyatı", "LY-1159", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1168,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 429000m, 458.0, "Uşak", 2944m, 11.0, 3238m, true, 2, "İstanbul - Uşak Karton Kutu Ambalajları", "LY-9843", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1169,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 77000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 576.0, "Denizli", 4724m, 18.0, null, false, 3, "İstanbul - Denizli Paletli Gıda Kolileri", "LY-5824", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1170,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 155000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 736.0, "Şanlıurfa", 9555m, 26.0, 10510m, true, 3, "İzmir - Şanlıurfa İnşaat Malzemeleri Götürme", "LY-9336", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1171,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 318000m, 695.0, "Karabük", 9158m, 30.0, null, false, "İzmir - Karabük Oto Yedek Parça Nakliyesi", "LY-3768", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1172,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 127000m, 743.0, "Tunceli", 4491m, 13.0, null, false, 1, "İzmir - Tunceli İnşaat Malzemeleri Götürme", "LY-2243", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1173,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 256000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 615.0, "Artvin", 6906m, 25.0, 7597m, true, 2, "İzmir - Artvin Karton Kutu Ambalajları", "LY-8955", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1174,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 348000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 274.0, "Ankara", 2273m, 13.0, null, false, 2, "İzmir - Ankara Karton Kutu Ambalajları", "LY-3616", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1175,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 24000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 891.0, "Hatay", 11216m, 30.0, 12338m, true, 3, "Kars - Hatay Beyaz Eşya Dağıtımı", "LY-9770", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1176,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 210000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 159.0, "İstanbul", 1982m, 20.0, null, false, 1, "Kars - İstanbul Paletli Gıda Kolileri", "LY-1947", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1177,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 320000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 489.0, "Batman", 4341m, 18.0, null, false, 2, "Kars - Batman Plastik Hammadde Sevkiyatı", "LY-7493", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1178,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 487000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 674.0, "Gümüşhane", 10423m, 35.0, 11465m, true, "Kars - Gümüşhane Tarım Gübresi ve Tohum", "LY-7460", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1179,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 149000m, 792.0, "Mersin", 4754m, 11.0, null, false, 1, "Kars - Mersin Karton Kutu Ambalajları", "LY-2416", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1180,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 156000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 623.0, "Kırşehir", 6138m, 22.0, 6752m, true, "Kastamonu - Kırşehir Paletli Gıda Kolileri", "LY-3017", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1181,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 257000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 675.0, "Bilecik", 4807m, 15.0, null, false, 3, "Kastamonu - Bilecik Mobilya ve Ev Eşyası Taşıma", "LY-1476", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1182,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 191000m, 585.0, "Malatya", 6541m, 25.0, null, false, "Kastamonu - Malatya İnşaat Malzemeleri Götürme", "LY-5098", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1183,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 180000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 946.0, "Bayburt", 9762m, 10738m, true, 3, "Kastamonu - Bayburt Mobilya ve Ev Eşyası Taşıma", "LY-3185", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1184,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 68000m, 117.0, "Sakarya", 1598m, 22.0, null, false, 1, "Kastamonu - Sakarya Plastik Hammadde Sevkiyatı", "LY-5799", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1185,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 325000m, 540.0, "Giresun", 5917m, 20.0, 6509m, true, 3, "Kayseri - Giresun Tekstil Ürünleri Sevkiyatı", "LY-8208", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1186,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 241000m, 785.0, "Erzincan", 4509m, 12.0, null, false, "Kayseri - Erzincan Paletli Gıda Kolileri", "LY-6780", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1187,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 251000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 745.0, "Mardin", 11181m, null, false, 3, "Kayseri - Mardin Tekstil Ürünleri Sevkiyatı", "LY-1436", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1188,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 275000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 739.0, "Ağrı", 9939m, 31.0, 10933m, true, "Kayseri - Ağrı Beyaz Eşya Dağıtımı", "LY-5021", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1189,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 487000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 402.0, "Ağrı", 7237m, 33.0, null, false, 1, "Kayseri - Ağrı Makine Teçhizat Parçaları", "LY-5867", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1190,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 432000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 716.0, "Nevşehir", 10383m, 33.0, 11421m, true, 2, "Kırklareli - Nevşehir Beyaz Eşya Dağıtımı", "LY-7959", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1191,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 40000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 540.0, "Bayburt", 3132m, 12.0, null, false, 1, "Kırklareli - Bayburt Makine Teçhizat Parçaları", "LY-1318", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1192,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 362000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 255.0, "Kahramanmaraş", 3004m, 21.0, null, false, 2, "Kırklareli - Kahramanmaraş Tarım Gübresi ve Tohum", "LY-2753", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1193,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 440000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 137.0, "Muş", 2803m, 34.0, 3083m, true, 1, "Kırklareli - Muş Tarım Gübresi ve Tohum", "LY-2646", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1194,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 58000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 642.0, "Yozgat", 4153m, 14.0, null, false, "Kırklareli - Yozgat Oto Yedek Parça Nakliyesi", "LY-7663", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1195,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 168000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 401.0, "Kırıkkale", 6282m, 35.0, 6910m, true, "Kırşehir - Kırıkkale Oto Yedek Parça Nakliyesi", "LY-3006", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1196,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 389000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 523.0, "Sivas", 7999m, 29.0, null, false, 3, "Kırşehir - Sivas Beyaz Eşya Dağıtımı", "LY-9059", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1197,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 110000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 117.0, "Siirt", 1778m, 20.0, null, false, "Kırşehir - Siirt Tekstil Ürünleri Sevkiyatı", "LY-6653", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1198,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 231000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 122.0, "Karabük", 1561m, 17.0, 1717m, true, 1, "Kırşehir - Karabük Tekstil Ürünleri Sevkiyatı", "LY-3328", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1199,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 47000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 654.0, "Adıyaman", 8133m, 29.0, null, false, 1, "Kırşehir - Adıyaman Tarım Gübresi ve Tohum", "LY-3803", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1200,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 416000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 137.0, "Kilis", 3196m, 34.0, 3516m, true, 1, "Kocaeli - Kilis Makine Teçhizat Parçaları", "LY-8928", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1201,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 74000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 901.0, "Mersin", 9224m, 24.0, null, false, 1, "Kocaeli - Mersin Oto Yedek Parça Nakliyesi", "LY-6702", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1202,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 104000m, 874.0, "Tunceli", 12490m, 34.0, null, false, 3, "Kocaeli - Tunceli Oto Yedek Parça Nakliyesi", "LY-1421", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1203,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 185000m, 642.0, "Adıyaman", 4036m, 11.0, 4440m, true, 1, "Kocaeli - Adıyaman Tekstil Ürünleri Sevkiyatı", "LY-4342", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1204,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 289000m, 302.0, "Elazığ", 4292m, 29.0, null, false, "Kocaeli - Elazığ Tekstil Ürünleri Sevkiyatı", "LY-9025", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1205,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 398000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 604.0, "Artvin", 7904m, 29.0, 8694m, true, "Konya - Artvin Tekstil Ürünleri Sevkiyatı", "LY-9347", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1206,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 385000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 645.0, "Mardin", 8367m, 29.0, null, false, "Konya - Mardin Makine Teçhizat Parçaları", "LY-9703", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1207,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 188000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 740.0, "Muş", 10752m, 34.0, null, false, 1, "Konya - Muş Paletli Gıda Kolileri", "LY-8723", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1208,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 301000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 652.0, "Yalova", 6278m, 21.0, 6906m, true, 1, "Konya - Yalova Tarım Gübresi ve Tohum", "LY-8345", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1209,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 181000m, 358.0, "Aksaray", 3975m, 23.0, null, false, 3, "Konya - Aksaray Mobilya ve Ev Eşyası Taşıma", "LY-8973", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1210,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 328000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 836.0, "Burdur", 9857m, 27.0, 10843m, true, 3, "Kütahya - Burdur Plastik Hammadde Sevkiyatı", "LY-5826", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1211,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 72000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 683.0, 11026m, 33.0, null, false, 1, "Kütahya - Bartın Oto Yedek Parça Nakliyesi", "LY-7585", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1212,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 439000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 653.0, "Batman", 6163m, 20.0, null, false, 2, "Kütahya - Batman Oto Yedek Parça Nakliyesi", "LY-6746", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1213,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 165000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 214.0, "Ağrı", 2634m, 23.0, 2897m, true, 2, "Kütahya - Ağrı Makine Teçhizat Parçaları", "LY-7530", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1214,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 406000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 507.0, "Şanlıurfa", 6584m, 28.0, null, false, "Kütahya - Şanlıurfa İnşaat Malzemeleri Götürme", "LY-3203", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1215,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 327000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 353.0, "İzmir", 3227m, 17.0, 3550m, true, 3, "Malatya - İzmir Mobilya ve Ev Eşyası Taşıma", "LY-2970", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1216,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 462000m, 156.0, "Balıkesir", 2772m, 29.0, null, false, "Malatya - Balıkesir Paletli Gıda Kolileri", "LY-5162", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1217,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 40000m, 448.0, "Iğdır", 4303m, 21.0, null, false, "Malatya - Iğdır Makine Teçhizat Parçaları", "LY-7169", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1218,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 428000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 776.0, "Bartın", 6826m, 19.0, 7509m, true, 1, "Malatya - Bartın Tarım Gübresi ve Tohum", "LY-6626", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1219,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 98000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 270.0, "Niğde", 3190m, 24.0, null, false, 2, "Malatya - Niğde Karton Kutu Ambalajları", "LY-8485", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1220,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 132000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 760.0, "Kilis", 11272m, 35.0, 12399m, true, 3, "Manisa - Kilis Tarım Gübresi ve Tohum", "LY-2456", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1221,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 472000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 831.0, "Muğla", 4961m, 12.0, null, false, "Manisa - Muğla Karton Kutu Ambalajları", "LY-7571", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1222,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 182000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 356.0, "Ardahan", 5666m, 35.0, null, false, 2, "Manisa - Ardahan Tarım Gübresi ve Tohum", "LY-5256", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1223,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 150000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 216.0, "Siirt", 3156m, 29.0, 3472m, true, 1, "Manisa - Siirt Tarım Gübresi ve Tohum", "LY-9916", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1224,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 187000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 630.0, "Şırnak", 7743m, 28.0, null, false, 2, "Manisa - Şırnak Tekstil Ürünleri Sevkiyatı", "LY-5592", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1225,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 309000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 776.0, "Osmaniye", 4223m, 11.0, 4645m, true, "Kahramanmaraş - Osmaniye Karton Kutu Ambalajları", "LY-8559", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1226,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 205000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 575.0, "Burdur", 7375m, 29.0, null, false, 2, "Kahramanmaraş - Burdur Tekstil Ürünleri Sevkiyatı", "LY-6665", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1227,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 288000m, 607.0, "Kırşehir", 9043m, 34.0, null, false, "Kahramanmaraş - Kırşehir Beyaz Eşya Dağıtımı", "LY-8218", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1228,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 128000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 267.0, "Ordu", 4407m, 30.0, 4848m, true, 3, "Kahramanmaraş - Ordu Tekstil Ürünleri Sevkiyatı", "LY-7957", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1229,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 435000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 278.0, "Giresun", 2825m, 17.0, null, false, 3, "Kahramanmaraş - Giresun Tarım Gübresi ve Tohum", "LY-7805", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1230,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 495000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 325.0, "Sakarya", 2295m, 10.0, 2524m, true, "Mardin - Sakarya Tarım Gübresi ve Tohum", "LY-3419", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1231,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 117000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 226.0, "Antalya", 3932m, 31.0, null, false, 2, "Mardin - Antalya Karton Kutu Ambalajları", "LY-6343", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1232,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 493000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 886.0, "Hatay", 4891m, 11.0, null, false, 1, "Mardin - Hatay İnşaat Malzemeleri Götürme", "LY-6145", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1233,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 363000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 326.0, "İzmir", 5036m, 32.0, 5540m, true, 3, "Mardin - İzmir Paletli Gıda Kolileri", "LY-5216", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1234,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 291000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 578.0, "Adıyaman", 8421m, null, false, 2, "Mardin - Adıyaman İnşaat Malzemeleri Götürme", "LY-4352", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1235,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 46000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 379.0, "Manisa", 4942m, 29.0, 5436m, true, "Muğla - Manisa Oto Yedek Parça Nakliyesi", "LY-8282", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1236,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 150000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 785.0, "Ankara", 13025m, 34.0, null, false, 3, "Muğla - Ankara Oto Yedek Parça Nakliyesi", "LY-3065", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1237,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 112000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 943.0, 5475m, 11.0, null, false, 3, "Muğla - Van Tekstil Ürünleri Sevkiyatı", "LY-4742", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1238,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 294000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 308.0, "Şırnak", 4120m, 27.0, 4532m, true, "Muğla - Şırnak Beyaz Eşya Dağıtımı", "LY-1063", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1239,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 496000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 243.0, "Bolu", 4398m, 35.0, null, false, "Muğla - Bolu Plastik Hammadde Sevkiyatı", "LY-8034", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1240,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 139000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 340.0, "Iğdır", 4855m, 31.0, 5340m, true, 1, "Muş - Iğdır Oto Yedek Parça Nakliyesi", "LY-4402", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1241,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 415000m, 706.0, "Sivas", 9171m, 25.0, null, false, "Muş - Sivas Paletli Gıda Kolileri", "LY-8472", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1242,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 498000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 471.0, "Elazığ", 3259m, 12.0, null, false, "Muş - Elazığ Tekstil Ürünleri Sevkiyatı", "LY-8723", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1243,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 335000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 441.0, "Bursa", 5774m, 28.0, 6351m, true, 1, "Muş - Bursa İnşaat Malzemeleri Götürme", "LY-4310", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1244,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 75000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 944.0, "Aksaray", 8505m, 21.0, null, false, 2, "Muş - Aksaray Beyaz Eşya Dağıtımı", "LY-4612", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1245,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 66000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 322.0, "Aydın", 4430m, 30.0, 4873m, true, 2, "Nevşehir - Aydın Paletli Gıda Kolileri", "LY-3584", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1246,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 460000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 258.0, "Manisa", 3746m, 27.0, null, false, "Nevşehir - Manisa Tekstil Ürünleri Sevkiyatı", "LY-7881", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1247,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 477000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 673.0, "İzmir", 10399m, 35.0, null, false, 3, "Nevşehir - İzmir Makine Teçhizat Parçaları", "LY-5263", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1248,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 187000m, 827.0, "Ankara", 11062m, 27.0, 12168m, true, 2, "Nevşehir - Ankara Plastik Hammadde Sevkiyatı", "LY-2523", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1249,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 401000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 567.0, "İzmir", 3849m, 13.0, null, false, "Nevşehir - İzmir İnşaat Malzemeleri Götürme", "LY-4729", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1250,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 221000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 620.0, "Kastamonu", 5681m, 20.0, 6249m, true, 1, "Niğde - Kastamonu Oto Yedek Parça Nakliyesi", "LY-3204", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1251,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 391000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 270.0, "Kocaeli", 2943m, 19.0, null, false, 2, "Niğde - Kocaeli Beyaz Eşya Dağıtımı", "LY-6003", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1252,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 114000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 426.0, "Sivas", 6585m, 30.0, null, false, "Niğde - Sivas Beyaz Eşya Dağıtımı", "LY-6587", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1253,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 146000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 486.0, "Kilis", 5312m, 24.0, 5843m, true, 1, "Niğde - Kilis Mobilya ve Ev Eşyası Taşıma", "LY-3369", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1254,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 484000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 746.0, "Sakarya", 6654m, 19.0, null, false, 1, "Niğde - Sakarya Paletli Gıda Kolileri", "LY-3533", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1255,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 328000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 930.0, "Bingöl", 13848m, 35.0, 15233m, true, 2, "Ordu - Bingöl Tarım Gübresi ve Tohum", "LY-8756", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1256,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 39000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 150.0, "Bartın", 1439m, 15.0, null, false, 1, "Ordu - Bartın Plastik Hammadde Sevkiyatı", "LY-7354", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1257,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 318000m, 318.0, "Çorum", 2550m, 11.0, null, false, 1, "Ordu - Çorum Tekstil Ürünleri Sevkiyatı", "LY-2185", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1258,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 493000m, 219.0, "Sinop", 4567m, 34.0, 5024m, true, 1, "Ordu - Sinop Mobilya ve Ev Eşyası Taşıma", "LY-7798", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1259,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 45000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 328.0, "Niğde", 3169m, 20.0, null, false, 1, "Ordu - Niğde Beyaz Eşya Dağıtımı", "LY-7570", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1260,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 127000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 150.0, "Muğla", 2584m, 27.0, 2842m, true, "Rize - Muğla Makine Teçhizat Parçaları", "LY-5815", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1261,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 273000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 112.0, 1266m, 11.0, null, false, 2, "Rize - Amasya Paletli Gıda Kolileri", "LY-9762", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1262,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 357000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 698.0, "Mardin", 7086m, 19.0, null, false, 2, "Rize - Mardin Tarım Gübresi ve Tohum", "LY-6297", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1263,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 75000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 680.0, "Mersin", 3839m, 12.0, 4223m, true, "Rize - Mersin Mobilya ve Ev Eşyası Taşıma", "LY-6189", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1264,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 112000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 202.0, "Antalya", 2228m, 20.0, null, false, 3, "Rize - Antalya Oto Yedek Parça Nakliyesi", "LY-5900", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1265,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 254000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 352.0, "Kırklareli", 3943m, 19.0, 4337m, true, 2, "Sakarya - Kırklareli Karton Kutu Ambalajları", "LY-8085", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1266,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 36000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 856.0, "Adıyaman", 10466m, 29.0, null, false, 1, "Sakarya - Adıyaman Makine Teçhizat Parçaları", "LY-8065", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1267,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 397000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 470.0, "Erzincan", 5973m, 27.0, null, false, 1, "Sakarya - Erzincan İnşaat Malzemeleri Götürme", "LY-7721", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1268,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 173000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 948.0, "Tunceli", 9015m, 22.0, 9916m, true, "Sakarya - Tunceli İnşaat Malzemeleri Götürme", "LY-7037", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1269,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 82000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 519.0, "Yalova", 7433m, 33.0, null, false, 1, "Sakarya - Yalova İnşaat Malzemeleri Götürme", "LY-1319", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1270,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 346000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 318.0, "Siirt", 2372m, 12.0, 2609m, true, 3, "Samsun - Siirt Plastik Hammadde Sevkiyatı", "LY-3974", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1271,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 480000m, 554.0, "Mardin", 4304m, 15.0, null, false, 3, "Samsun - Mardin Mobilya ve Ev Eşyası Taşıma", "LY-1020", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1272,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 468000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 379.0, "Ağrı", 4077m, 17.0, null, false, 3, "Samsun - Ağrı Beyaz Eşya Dağıtımı", "LY-6500", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1273,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 96000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 910.0, "Aydın", 5328m, 13.0, 5861m, true, "Samsun - Aydın Makine Teçhizat Parçaları", "LY-4120", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1274,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 346000m, 741.0, "Kırklareli", 5588m, 16.0, null, false, 1, "Samsun - Kırklareli Oto Yedek Parça Nakliyesi", "LY-4944", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1275,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 495000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 867.0, "Uşak", 7584m, 19.0, 8342m, true, "Siirt - Uşak Makine Teçhizat Parçaları", "LY-7790", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1276,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 197000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 185.0, "Konya", 3213m, 34.0, null, false, 3, "Siirt - Konya Mobilya ve Ev Eşyası Taşıma", "LY-8282", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1277,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 22000m, 629.0, "Aydın", 3541m, 12.0, null, false, "Siirt - Aydın Tekstil Ürünleri Sevkiyatı", "LY-6894", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1278,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 238000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 583.0, "Malatya", 3536m, 12.0, 3890m, true, 1, "Siirt - Malatya Beyaz Eşya Dağıtımı", "LY-6486", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1279,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 104000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 752.0, "Kütahya", 3913m, 11.0, null, false, 2, "Siirt - Kütahya Karton Kutu Ambalajları", "LY-8063", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1280,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 138000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 270.0, "Adana", 2042m, 13.0, 2246m, true, 1, "Sinop - Adana Tarım Gübresi ve Tohum", "LY-4744", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1281,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 134000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 422.0, "Erzincan", 5000m, 22.0, null, false, 2, "Sinop - Erzincan Tekstil Ürünleri Sevkiyatı", "LY-2669", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1282,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 25000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 321.0, "Afyonkarahisar", 3221m, 21.0, null, false, 3, "Sinop - Afyonkarahisar Beyaz Eşya Dağıtımı", "LY-5668", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1283,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 20000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 236.0, "Kırşehir", 3446m, 31.0, 3791m, true, 2, "Sinop - Kırşehir Mobilya ve Ev Eşyası Taşıma", "LY-4588", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1284,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 186000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 309.0, "Mersin", 4147m, 28.0, null, false, 2, "Sinop - Mersin Oto Yedek Parça Nakliyesi", "LY-5866", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1285,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 62000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 345.0, "Hakkari", 4426m, 28.0, 4869m, true, "Sivas - Hakkari Karton Kutu Ambalajları", "LY-6157", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1286,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 125000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 843.0, "Mardin", 11078m, 31.0, null, false, "Sivas - Mardin Beyaz Eşya Dağıtımı", "LY-7544", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1287,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 96000m, 232.0, "Konya", 1966m, 12.0, null, false, "Sivas - Konya Beyaz Eşya Dağıtımı", "LY-5526", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1288,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 488000m, 763.0, "Amasya", 7092m, 20.0, 7801m, true, 3, "Sivas - Amasya Mobilya ve Ev Eşyası Taşıma", "LY-4356", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1289,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 344000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 346.0, "Muğla", 3197m, 17.0, null, false, "Sivas - Muğla Mobilya ve Ev Eşyası Taşıma", "LY-6148", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1290,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 763.0, "Mardin", 3992m, 11.0, 4391m, true, 1, "Tekirdağ - Mardin Paletli Gıda Kolileri", "LY-8097", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1291,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 39000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 635.0, "Çankırı", 8214m, 26.0, null, false, 2, "Tekirdağ - Çankırı Mobilya ve Ev Eşyası Taşıma", "LY-4525", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1292,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 481000m, 813.0, "Siirt", 5209m, 13.0, null, false, 3, "Tekirdağ - Siirt Tarım Gübresi ve Tohum", "LY-7347", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1293,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 80000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 122.0, "Hakkari", 1751m, 24.0, 1926m, true, 3, "Tekirdağ - Hakkari Karton Kutu Ambalajları", "LY-9541", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1294,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 271000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 856.0, "Adıyaman", 14275m, 34.0, null, false, "Tekirdağ - Adıyaman Plastik Hammadde Sevkiyatı", "LY-1097", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1295,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 500000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 573.0, "Afyonkarahisar", 3980m, 13.0, 4378m, true, 3, "Tokat - Afyonkarahisar Plastik Hammadde Sevkiyatı", "LY-5774", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1296,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 24000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 737.0, "Giresun", 9958m, 32.0, null, false, "Tokat - Giresun Tekstil Ürünleri Sevkiyatı", "LY-1731", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1297,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 394000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 392.0, "Antalya", 6978m, 33.0, null, false, 2, "Tokat - Antalya Makine Teçhizat Parçaları", "LY-4628", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1298,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 41000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 646.0, "Mardin", 6565m, 20.0, 7222m, true, "Tokat - Mardin Makine Teçhizat Parçaları", "LY-4873", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1299,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 93000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 603.0, "Niğde", 6623m, 25.0, null, false, 1, "Tokat - Niğde Tekstil Ürünleri Sevkiyatı", "LY-1331", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1300,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 320000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 228.0, "Kırıkkale", 2097m, 14.0, 2307m, true, 2, "Trabzon - Kırıkkale Plastik Hammadde Sevkiyatı", "LY-5014", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1301,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 397000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 153.0, "Aksaray", 2611m, 28.0, null, false, 1, "Trabzon - Aksaray İnşaat Malzemeleri Götürme", "LY-3354", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1302,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 432000m, 566.0, 3422m, 11.0, null, false, 3, "Trabzon - Elazığ Karton Kutu Ambalajları", "LY-5507", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1303,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 440000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 576.0, "Kilis", 3244m, 10.0, 3568m, true, "Trabzon - Kilis Karton Kutu Ambalajları", "LY-1552", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1304,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 207000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 180.0, "Mardin", 2717m, 23.0, null, false, 2, "Trabzon - Mardin Tarım Gübresi ve Tohum", "LY-6268", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1305,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 66000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 666.0, "Çorum", 5628m, 19.0, 6191m, true, 1, "Tunceli - Çorum Oto Yedek Parça Nakliyesi", "LY-1722", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1306,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 91000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 811.0, "Şırnak", 5133m, 14.0, null, false, 3, "Tunceli - Şırnak Plastik Hammadde Sevkiyatı", "LY-8259", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1307,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 271000m, 384.0, "Malatya", 3075m, 15.0, null, false, 3, "Tunceli - Malatya Beyaz Eşya Dağıtımı", "LY-2903", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1308,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 186000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 805.0, "Şırnak", 11312m, 33.0, 12443m, true, "Tunceli - Şırnak Oto Yedek Parça Nakliyesi", "LY-5945", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1309,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 70000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 896.0, "Bursa", 7738m, 20.0, null, false, 1, "Tunceli - Bursa Makine Teçhizat Parçaları", "LY-5782", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1310,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 202000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 882.0, "Çanakkale", 6081m, 13.0, 6689m, true, "Şanlıurfa - Çanakkale Mobilya ve Ev Eşyası Taşıma", "LY-4552", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1311,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 244000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 805.0, "Kütahya", 9116m, 26.0, null, false, 1, "Şanlıurfa - Kütahya Makine Teçhizat Parçaları", "LY-6669", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1312,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 242000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 734.0, "Erzurum", 6320m, 19.0, null, false, 1, "Şanlıurfa - Erzurum Makine Teçhizat Parçaları", "LY-3312", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1313,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 96000m, 241.0, "Kütahya", 4455m, 34.0, 4900m, true, "Şanlıurfa - Kütahya Karton Kutu Ambalajları", "LY-9471", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1314,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 346000m, 412.0, "Bayburt", 4801m, 24.0, null, false, 3, "Şanlıurfa - Bayburt Oto Yedek Parça Nakliyesi", "LY-1409", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1315,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 491000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 200.0, "Yozgat", 3311m, 29.0, 3642m, true, 3, "Uşak - Yozgat Beyaz Eşya Dağıtımı", "LY-4282", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1316,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 225000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", "Karabük", 4865m, 25.0, null, false, 2, "Uşak - Karabük Tarım Gübresi ve Tohum", "LY-1500", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1317,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 25000m, 427.0, "Gümüşhane", 6890m, 32.0, null, false, "Uşak - Gümüşhane Oto Yedek Parça Nakliyesi", "LY-6827", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1318,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 46000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 118.0, "Erzurum", 1065m, 11.0, 1172m, true, "Uşak - Erzurum Mobilya ve Ev Eşyası Taşıma", "LY-4663", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1319,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 84000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 144.0, "İstanbul", 1390m, 14.0, null, false, 2, "Uşak - İstanbul Karton Kutu Ambalajları", "LY-3966", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1320,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 484000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 781.0, "Kayseri", 10981m, 32.0, 12079m, true, "Van - Kayseri Oto Yedek Parça Nakliyesi", "LY-3443", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1321,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 360000m, 846.0, "Diyarbakır", 4881m, 10.0, null, false, "Van - Diyarbakır İnşaat Malzemeleri Götürme", "LY-3481", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1322,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 67000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 897.0, "Yalova", 4873m, 12.0, null, false, "Van - Yalova Oto Yedek Parça Nakliyesi", "LY-4117", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1323,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 112000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 182.0, "Bingöl", 1995m, 19.0, 2194m, true, 1, "Van - Bingöl Paletli Gıda Kolileri", "LY-2860", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1324,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 302000m, 675.0, "Bitlis", 8092m, 27.0, null, false, 3, "Van - Bitlis Tekstil Ürünleri Sevkiyatı", "LY-6706", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1325,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 203000m, 326.0, "Bitlis", 4745m, 31.0, 5220m, true, 2, "Yozgat - Bitlis Karton Kutu Ambalajları", "LY-3718", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1326,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 36000m, 528.0, "Çankırı", 4760m, 20.0, null, false, 3, "Yozgat - Çankırı Beyaz Eşya Dağıtımı", "LY-5666", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1327,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 285000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 299.0, "Uşak", 2938m, 18.0, null, false, 3, "Yozgat - Uşak Oto Yedek Parça Nakliyesi", "LY-4492", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1328,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 315000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 740.0, "Diyarbakır", 5022m, 12.0, 5524m, true, 1, "Yozgat - Diyarbakır Oto Yedek Parça Nakliyesi", "LY-7154", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1329,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 336000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 427.0, "Uşak", 5960m, 30.0, null, false, 2, "Yozgat - Uşak Oto Yedek Parça Nakliyesi", "LY-9179", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1330,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 327000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 293.0, "Adıyaman", 5534m, 34.0, 6087m, true, "Zonguldak - Adıyaman Makine Teçhizat Parçaları", "LY-6324", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1331,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 106000m, 293.0, "Elazığ", 2833m, 19.0, null, false, 1, "Zonguldak - Elazığ İnşaat Malzemeleri Götürme", "LY-9545", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1332,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 431000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 572.0, "Şırnak", 3905m, 13.0, null, false, 1, "Zonguldak - Şırnak Mobilya ve Ev Eşyası Taşıma", "LY-1390", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1333,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 418000m, 614.0, "Osmaniye", 7058m, 25.0, 7764m, true, 1, "Zonguldak - Osmaniye Tarım Gübresi ve Tohum", "LY-6967", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1334,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 232000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 931.0, "Ardahan", 7808m, 19.0, null, false, 2, "Zonguldak - Ardahan Tekstil Ürünleri Sevkiyatı", "LY-4314", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1335,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 71000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 529.0, "Diyarbakır", 6496m, 28.0, 7146m, true, "Aksaray - Diyarbakır Tekstil Ürünleri Sevkiyatı", "LY-4853", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1336,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 238000m, 349.0, "Kayseri", 2972m, 16.0, null, false, "Aksaray - Kayseri Plastik Hammadde Sevkiyatı", "LY-1636", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1337,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 396000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 892.0, "Rize", 5955m, 12.0, null, false, 3, "Aksaray - Rize Paletli Gıda Kolileri", "LY-5174", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1338,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 498000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 819.0, "Isparta", 6567m, 17.0, 7224m, true, 3, "Aksaray - Isparta Makine Teçhizat Parçaları", "LY-2418", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1339,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 70000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 713.0, "Iğdır", 3422m, 10.0, null, false, "Aksaray - Iğdır Karton Kutu Ambalajları", "LY-2667", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1340,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 71000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 484.0, "Bartın", 5024m, 23.0, 5526m, true, 2, "Bayburt - Bartın İnşaat Malzemeleri Götürme", "LY-3053", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1341,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 391000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 444.0, "Elazığ", 5509m, 26.0, null, false, "Bayburt - Elazığ Tekstil Ürünleri Sevkiyatı", "LY-6142", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1342,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 221000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 239.0, "Tunceli", 3028m, 20.0, null, false, 1, "Bayburt - Tunceli Tarım Gübresi ve Tohum", "LY-1741", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1343,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 375000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 315.0, "Bolu", 4339m, 23.0, 4773m, true, "Bayburt - Bolu İnşaat Malzemeleri Götürme", "LY-6375", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1344,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 211000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 939.0, "Artvin", 6721m, 16.0, null, false, 2, "Bayburt - Artvin Tekstil Ürünleri Sevkiyatı", "LY-9406", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1345,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 216000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 520.0, "Niğde", 4668m, 19.0, 5135m, true, 3, "Karaman - Niğde Tekstil Ürünleri Sevkiyatı", "LY-8036", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1346,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 492000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 422.0, "İzmir", 6225m, 31.0, null, false, "Karaman - İzmir Makine Teçhizat Parçaları", "LY-1258", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1347,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 25000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 799.0, "Erzurum", 8835m, 26.0, null, false, "Karaman - Erzurum Makine Teçhizat Parçaları", "LY-1434", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1348,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 21000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 633.0, "Aksaray", 3306m, 11.0, 3637m, true, "Karaman - Aksaray Makine Teçhizat Parçaları", "LY-8009", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1349,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 81000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 269.0, "Batman", 2733m, 20.0, null, false, 1, "Karaman - Batman Paletli Gıda Kolileri", "LY-8295", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1350,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 357000m, 280.0, "Ordu", 3046m, 16.0, 3351m, true, "Kırıkkale - Ordu Tarım Gübresi ve Tohum", "LY-7466", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1351,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 494000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 150.0, "Aksaray", 1902m, 11.0, null, false, 2, "Kırıkkale - Aksaray İnşaat Malzemeleri Götürme", "LY-4262", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1352,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 35000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 782.0, "Bilecik", 4289m, 12.0, null, false, 2, "Kırıkkale - Bilecik Mobilya ve Ev Eşyası Taşıma", "LY-8904", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1353,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 358000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 648.0, "Niğde", 4487m, 14.0, 4936m, true, 1, "Kırıkkale - Niğde İnşaat Malzemeleri Götürme", "LY-3082", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1354,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 305000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 574.0, "Aksaray", 5942m, 19.0, null, false, 1, "Kırıkkale - Aksaray Paletli Gıda Kolileri", "LY-5425", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1355,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 453000m, 371.0, "Mersin", 6728m, 33.0, 7401m, true, 1, "Batman - Mersin Paletli Gıda Kolileri", "LY-4126", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1356,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 375000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 379.0, "Hatay", 4210m, 22.0, null, false, 2, "Batman - Hatay Tarım Gübresi ve Tohum", "LY-8380", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1357,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 283000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 887.0, "İstanbul", 9653m, 25.0, null, false, "Batman - İstanbul Mobilya ve Ev Eşyası Taşıma", "LY-8836", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1358,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 282000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 108.0, "Kilis", 1214m, 10.0, 1335m, true, 2, "Batman - Kilis Karton Kutu Ambalajları", "LY-5352", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1359,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 292000m, 258.0, "Konya", 1824m, 10.0, null, false, 2, "Batman - Konya Tekstil Ürünleri Sevkiyatı", "LY-1280", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1360,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 247000m, 756.0, "Yalova", 8307m, 25.0, 9138m, true, "Şırnak - Yalova Karton Kutu Ambalajları", "LY-8398", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1361,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 411000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 605.0, "Mersin", 5267m, 18.0, null, false, 3, "Şırnak - Mersin İnşaat Malzemeleri Götürme", "LY-2486", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1362,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 251000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 599.0, "Kastamonu", 8418m, 32.0, null, false, 2, "Şırnak - Kastamonu Tarım Gübresi ve Tohum", "LY-2023", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1363,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 451000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 766.0, "Kırklareli", 7692m, 22.0, 8461m, true, 2, "Şırnak - Kırklareli Mobilya ve Ev Eşyası Taşıma", "LY-6618", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1364,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 419000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 422.0, "Muğla", 5328m, 22.0, null, false, "Şırnak - Muğla Tarım Gübresi ve Tohum", "LY-8891", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1365,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 392000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 250.0, "Çanakkale", 3092m, 22.0, 3401m, true, "Bartın - Çanakkale Tarım Gübresi ve Tohum", "LY-9710", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1366,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 138000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 682.0, "Muğla", 5003m, 16.0, null, false, 1, "Bartın - Muğla Paletli Gıda Kolileri", "LY-3045", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1367,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 54000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 736.0, "Karabük", 5559m, null, false, 3, "Bartın - Karabük Paletli Gıda Kolileri", "LY-5903", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1368,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 44000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 681.0, "Hatay", 4358m, 14.0, 4794m, true, "Bartın - Hatay İnşaat Malzemeleri Götürme", "LY-4363", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1369,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 465000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 358.0, "Erzurum", 5227m, 25.0, null, false, 2, "Bartın - Erzurum Paletli Gıda Kolileri", "LY-6843", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1370,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 206000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 453.0, "Yozgat", 7048m, 35.0, 7753m, true, "Ardahan - Yozgat Tarım Gübresi ve Tohum", "LY-1913", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1371,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 202000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 818.0, "Çorum", 9838m, 24.0, null, false, 1, "Ardahan - Çorum Beyaz Eşya Dağıtımı", "LY-8832", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1372,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 500000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 444.0, "Eskişehir", 2954m, 11.0, null, false, "Ardahan - Eskişehir Paletli Gıda Kolileri", "LY-6015", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1373,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 129000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 870.0, "Iğdır", 8727m, 20.0, 9600m, true, 3, "Ardahan - Iğdır Plastik Hammadde Sevkiyatı", "LY-9496", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1374,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 462000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 869.0, "İstanbul", 9652m, 25.0, null, false, "Ardahan - İstanbul Karton Kutu Ambalajları", "LY-6381", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1375,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 386000m, 899.0, "Hatay", 7718m, 19.0, 8490m, true, 1, "Iğdır - Hatay İnşaat Malzemeleri Götürme", "LY-2851", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1376,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 178000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 539.0, "Erzincan", 7577m, 32.0, null, false, 2, "Iğdır - Erzincan Mobilya ve Ev Eşyası Taşıma", "LY-6354", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1377,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 475000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 745.0, "Çanakkale", 5743m, 16.0, null, false, "Iğdır - Çanakkale Karton Kutu Ambalajları", "LY-1034", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1378,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 472000m, 913.0, 13717m, 30.0, 15089m, true, "Iğdır - Ardahan Beyaz Eşya Dağıtımı", "LY-2969", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1379,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 254000m, 702.0, "Muş", 8617m, null, false, 2, "Iğdır - Muş Tekstil Ürünleri Sevkiyatı", "LY-4616", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1380,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 128000m, 436.0, "Adıyaman", 4988m, 25.0, 5487m, true, 2, "Yalova - Adıyaman Plastik Hammadde Sevkiyatı", "LY-3573", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1381,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 253000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 279.0, "Muş", 4659m, 35.0, null, false, "Yalova - Muş Karton Kutu Ambalajları", "LY-9366", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1382,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 120000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 789.0, "Şanlıurfa", 4723m, 13.0, null, false, 3, "Yalova - Şanlıurfa Paletli Gıda Kolileri", "LY-3834", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1383,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 181000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 543.0, 6980m, 29.0, 7678m, true, 3, "Yalova - Gümüşhane İnşaat Malzemeleri Götürme", "LY-5705", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1384,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 315000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 235.0, "Erzurum", 2601m, 19.0, null, false, 3, "Yalova - Erzurum Karton Kutu Ambalajları", "LY-9530", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1385,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 442000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 229.0, "Bingöl", 2682m, 19.0, 2950m, true, "Karabük - Bingöl Oto Yedek Parça Nakliyesi", "LY-5066", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1386,
                columns: new[] { "AssignedDriverId", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 358000m, 890.0, "İstanbul", 5130m, 12.0, null, false, "Karabük - İstanbul Mobilya ve Ev Eşyası Taşıma", "LY-8021", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1387,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 88000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 272.0, "Osmaniye", 2655m, 19.0, null, false, 1, "Karabük - Osmaniye Mobilya ve Ev Eşyası Taşıma", "LY-4822", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1388,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 27000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 200.0, "Şanlıurfa", 3007m, 31.0, 3308m, true, 2, "Karabük - Şanlıurfa Paletli Gıda Kolileri", "LY-4911", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1389,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 306000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 903.0, "Denizli", 5140m, 12.0, null, false, 2, "Karabük - Denizli Tekstil Ürünleri Sevkiyatı", "LY-4207", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1390,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 465000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 163.0, "Ardahan", 2384m, 17.0, 2622m, true, 1, "Kilis - Ardahan Karton Kutu Ambalajları", "LY-6911", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1391,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 52000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 751.0, "Trabzon", 11066m, 35.0, null, false, 1, "Kilis - Trabzon Paletli Gıda Kolileri", "LY-3392", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1392,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 153000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 616.0, "Bartın", 4349m, 15.0, null, false, 3, "Kilis - Bartın Paletli Gıda Kolileri", "LY-7926", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1393,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 365000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 791.0, "Malatya", 4978m, 13.0, 5476m, true, 2, "Kilis - Malatya Tarım Gübresi ve Tohum", "LY-7309", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1394,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 87000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 923.0, "İzmir", 6125m, 15.0, null, false, "Kilis - İzmir Makine Teçhizat Parçaları", "LY-4936", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1395,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 160000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 104.0, "Diyarbakır", 1450m, 19.0, 1595m, true, 3, "Osmaniye - Diyarbakır Tarım Gübresi ve Tohum", "LY-2371", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1396,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 409000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 933.0, "Aksaray", 10058m, 21.0, null, false, 3, "Osmaniye - Aksaray Plastik Hammadde Sevkiyatı", "LY-6432", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1397,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 391000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 294.0, "Kırklareli", 3594m, 19.0, null, false, 2, "Osmaniye - Kırklareli Mobilya ve Ev Eşyası Taşıma", "LY-5674", null, null, 1.1499999999999999 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1398,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 354000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 172.0, "Ankara", 2161m, 19.0, 2377m, true, 2, "Osmaniye - Ankara Mobilya ve Ev Eşyası Taşıma", "LY-9231", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1399,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 226000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 781.0, "Aksaray", 9786m, 29.0, null, false, 2, "Osmaniye - Aksaray Beyaz Eşya Dağıtımı", "LY-4418", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1400,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 486000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 703.0, "Karaman", 6610m, 20.0, 7271m, true, "Düzce - Karaman Plastik Hammadde Sevkiyatı", "LY-6884", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1401,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 431000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 769.0, "Bartın", 7698m, 22.0, null, false, "Düzce - Bartın Plastik Hammadde Sevkiyatı", "LY-2976", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1402,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 236000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 744.0, "Kocaeli", 6093m, 18.0, null, false, 2, "Düzce - Kocaeli Mobilya ve Ev Eşyası Taşıma", "LY-2019", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1403,
                columns: new[] { "AssignedDriverId", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, 351000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 104.0, "Mersin", 2016m, 28.0, 2218m, true, "Düzce - Mersin Plastik Hammadde Sevkiyatı", "LY-1886", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1404,
                columns: new[] { "AssignedDriverId", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "InstantBookPrice", "IsInstantBook", "RequiredLevel", "Title", "VerificationCode", "WaybillOcrText", "WaybillUrl", "WeatherDemandMultiplier" },
                values: new object[] { null, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 41000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 799.0, "Şırnak", 5335m, 15.0, null, false, 1, "Düzce - Şırnak İnşaat Malzemeleri Götürme", "LY-3073", null, null, 1.0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ParentFleetOwnerId", "SenderRating", "SenderRatingCount" },
                values: new object[] { null, 5.0, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ParentFleetOwnerId", "SenderRating", "SenderRatingCount" },
                values: new object[] { null, 5.0, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ParentFleetOwnerId", "SenderRating", "SenderRatingCount" },
                values: new object[] { null, 5.0, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ParentFleetOwnerId", "SenderRating", "SenderRatingCount" },
                values: new object[] { null, 5.0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PayoutRequests_UserId",
                table: "PayoutRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderReviews_AdId",
                table: "SenderReviews",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderReviews_CarrierId",
                table: "SenderReviews",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderReviews_SenderId",
                table: "SenderReviews",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PayoutRequests");

            migrationBuilder.DropTable(
                name: "SenderReviews");

            migrationBuilder.DropColumn(
                name: "ParentFleetOwnerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SenderRating",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SenderRatingCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AssignedDriverId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "InstantBookPrice",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "IsInstantBook",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "WaybillOcrText",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "WaybillUrl",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "WeatherDemandMultiplier",
                table: "Ads");

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1000,
                columns: new[] { "CargoImageUrl", "Description", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", "Adana - Samsun Oto Yedek Parça Nakliyesi", "LY-5616" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 263000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 299.0, "Tunceli", 2677m, 16.0, 1, "Adana - Tunceli İnşaat Malzemeleri Götürme", "LY-5657" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 93000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 590.0, "Yozgat", 5313m, 20.0, 1, "Adana - Yozgat Karton Kutu Ambalajları", "LY-5859" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 353000m, 225.0, "Sivas", 3823m, 33.0, 2, "Adana - Sivas Paletli Gıda Kolileri", "LY-3773" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 407000m, 103.0, "Zonguldak", 1855m, 23.0, 3, "Adana - Zonguldak İnşaat Malzemeleri Götürme", "LY-1237" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 140000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 632.0, "Uşak", 3674m, 12.0, 3, "Adıyaman - Uşak Oto Yedek Parça Nakliyesi", "LY-2292" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1006,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 222000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 538.0, "Muş", 3089m, 11.0, 3, "Adıyaman - Muş Plastik Hammadde Sevkiyatı", "LY-1119" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1007,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 54000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 158.0, "Edirne", 2324m, 28.0, 2, "Adıyaman - Edirne Tekstil Ürünleri Sevkiyatı", "LY-4952" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1008,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 26000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 107.0, "Kocaeli", 1853m, 31.0, 1, "Adıyaman - Kocaeli Tekstil Ürünleri Sevkiyatı", "LY-1310" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1009,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 316000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 492.0, "Iğdır", 4555m, 19.0, 1, "Adıyaman - Iğdır İnşaat Malzemeleri Götürme", "LY-4932" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 456000m, 440.0, "Malatya", 3948m, 17.0, 2, "Afyonkarahisar - Malatya Karton Kutu Ambalajları", "LY-8935" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1011,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 69000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 704.0, "Gaziantep", 4511m, 14.0, 2, "Afyonkarahisar - Gaziantep İnşaat Malzemeleri Götürme", "LY-2336" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1012,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 494000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 602.0, "Çankırı", 6532m, 23.0, 3, "Afyonkarahisar - Çankırı Plastik Hammadde Sevkiyatı", "LY-3605" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1013,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 186000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 653.0, 3298m, 10.0, 3, "Afyonkarahisar - Düzce Tekstil Ürünleri Sevkiyatı", "LY-3388" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1014,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 65000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 603.0, "Çankırı", 5389m, 20.0, 3, "Afyonkarahisar - Çankırı Paletli Gıda Kolileri", "LY-3891" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1015,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 40000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 801.0, "Trabzon", 3744m, 10.0, "Ağrı - Trabzon Tarım Gübresi ve Tohum", "LY-9335" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1016,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 320000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 563.0, "Elazığ", 6675m, 26.0, 1, "Ağrı - Elazığ Oto Yedek Parça Nakliyesi", "LY-1266" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1017,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 85000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 939.0, "Iğdır", 11853m, 30.0, 3, "Ağrı - Iğdır Paletli Gıda Kolileri", "LY-6039" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1018,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 208000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 203.0, "Sivas", 2738m, 25.0, "Ağrı - Sivas Mobilya ve Ev Eşyası Taşıma", "LY-9674" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1019,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 81000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 905.0, "Malatya", 11803m, "Ağrı - Malatya Tekstil Ürünleri Sevkiyatı", "LY-9462" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 80000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 602.0, "Mersin", 5396m, 20.0, "Amasya - Mersin Makine Teçhizat Parçaları", "LY-2553" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 415000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 623.0, "Malatya", 9388m, "Amasya - Malatya Oto Yedek Parça Nakliyesi", "LY-5730" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 111000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 854.0, "Diyarbakır", 9834m, 27.0, 1, "Amasya - Diyarbakır Oto Yedek Parça Nakliyesi", "LY-6760" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 394000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 784.0, "İzmir", 10929m, 32.0, 3, "Amasya - İzmir Makine Teçhizat Parçaları", "LY-9016" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1024,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 325000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 599.0, "Bitlis", 4419m, 15.0, 2, "Amasya - Bitlis Karton Kutu Ambalajları", "LY-8254" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1025,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 274000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 712.0, "Kütahya", 5046m, 15.0, 3, "Ankara - Kütahya Beyaz Eşya Dağıtımı", "LY-9412" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1026,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 102000m, 282.0, "Amasya", 2632m, 18.0, "Ankara - Amasya Oto Yedek Parça Nakliyesi", "LY-5230" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1027,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 500000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 748.0, "Kastamonu", 9078m, 27.0, 2, "Ankara - Kastamonu Tarım Gübresi ve Tohum", "LY-2651" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1028,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 479000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 620.0, "Muş", 5939m, 20.0, 1, "Ankara - Muş Mobilya ve Ev Eşyası Taşıma", "LY-3811" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1029,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 163000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 857.0, "Batman", 4091m, 10.0, "Ankara - Batman Tekstil Ürünleri Sevkiyatı", "LY-4698" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1030,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 472000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 936.0, "Sakarya", 7337m, 17.0, 3, "Antalya - Sakarya Tekstil Ürünleri Sevkiyatı", "LY-6915" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1031,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 185000m, 543.0, "Siirt", 4812m, 19.0, 1, "Antalya - Siirt Plastik Hammadde Sevkiyatı", "LY-6449" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1032,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 425000m, 184.0, "Sakarya", 1882m, 13.0, 1, "Antalya - Sakarya Makine Teçhizat Parçaları", "LY-1005" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1033,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 329000m, 232.0, "Gümüşhane", 2128m, 14.0, "Antalya - Gümüşhane Makine Teçhizat Parçaları", "LY-6902" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1034,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 191000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 654.0, "Ordu", 9062m, 32.0, "Antalya - Ordu Mobilya ve Ev Eşyası Taşıma", "LY-2758" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1035,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 217000m, 556.0, "Manisa", 6722m, 27.0, 2, "Artvin - Manisa Makine Teçhizat Parçaları", "LY-3030" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1036,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 172000m, 791.0, "Malatya", 9531m, 28.0, 2, "Artvin - Malatya Karton Kutu Ambalajları", "LY-9908" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1037,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 222000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 135.0, "Karaman", 1802m, 20.0, 1, "Artvin - Karaman Beyaz Eşya Dağıtımı", "LY-1016" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1038,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 363000m, 362.0, "Kayseri", 4049m, 22.0, 2, "Artvin - Kayseri Tekstil Ürünleri Sevkiyatı", "LY-8172" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1039,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "Title", "VerificationCode" },
                values: new object[] { 120000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 898.0, "Bartın", 8882m, "Artvin - Bartın Tarım Gübresi ve Tohum", "LY-6758" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1040,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 72000m, 375.0, "Kocaeli", 2222m, 11.0, 3, "Aydın - Kocaeli Plastik Hammadde Sevkiyatı", "LY-6121" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1041,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 72000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 214.0, "Hatay", 2198m, 19.0, 1, "Aydın - Hatay Plastik Hammadde Sevkiyatı", "LY-3118" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1042,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 307000m, 801.0, "Zonguldak", 7215m, 20.0, 1, "Aydın - Zonguldak Karton Kutu Ambalajları", "LY-5899" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1043,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 275000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 653.0, "Adana", 3909m, 12.0, 3, "Aydın - Adana Beyaz Eşya Dağıtımı", "LY-9111" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1044,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 433000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 399.0, "Şırnak", 4125m, 20.0, 3, "Aydın - Şırnak Tarım Gübresi ve Tohum", "LY-8300" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1045,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 427000m, 778.0, "Artvin", 11508m, 34.0, "Balıkesir - Artvin Karton Kutu Ambalajları", "LY-8256" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1046,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 150000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 870.0, "Kars", 5870m, 15.0, 3, "Balıkesir - Kars İnşaat Malzemeleri Götürme", "LY-9265" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1047,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 428000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 819.0, "Amasya", 7152m, 19.0, "Balıkesir - Amasya Paletli Gıda Kolileri", "LY-2187" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1048,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 286000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 923.0, "Konya", 4478m, 10.0, "Balıkesir - Konya İnşaat Malzemeleri Götürme", "LY-2792" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1049,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 291000m, 494.0, "Bitlis", 4545m, "Balıkesir - Bitlis Karton Kutu Ambalajları", "LY-9950" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1050,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 156000m, 551.0, "Niğde", 3080m, 11.0, "Bilecik - Niğde Makine Teçhizat Parçaları", "LY-9679" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1051,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 439000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 446.0, "Denizli", 6469m, 31.0, 1, "Bilecik - Denizli Tarım Gübresi ve Tohum", "LY-8541" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1052,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 87000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 312.0, "Şırnak", 4581m, 32.0, 2, "Bilecik - Şırnak Plastik Hammadde Sevkiyatı", "LY-7887" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1053,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 87000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 340.0, "Samsun", 3171m, 19.0, "Bilecik - Samsun Paletli Gıda Kolileri", "LY-5616" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1054,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 321000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 682.0, "Kayseri", 4640m, 14.0, 3, "Bilecik - Kayseri İnşaat Malzemeleri Götürme", "LY-9640" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1055,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 286000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 338.0, "Erzincan", 3490m, 20.0, "Bingöl - Erzincan Paletli Gıda Kolileri", "LY-4475" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1056,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 226000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 506.0, "Muş", 7405m, 33.0, 3, "Bingöl - Muş Paletli Gıda Kolileri", "LY-2836" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1057,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 366000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 184.0, "Yalova", 2117m, 17.0, "Bingöl - Yalova Beyaz Eşya Dağıtımı", "LY-9869" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1058,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 272000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 323.0, "Niğde", 3614m, 22.0, "Bingöl - Niğde Plastik Hammadde Sevkiyatı", "LY-2573" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1059,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 128000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 205.0, "Ağrı", 1776m, 14.0, 1, "Bingöl - Ağrı Karton Kutu Ambalajları", "LY-9017" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1060,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 40000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 132.0, "Kars", 2230m, 32.0, 1, "Bitlis - Kars Beyaz Eşya Dağıtımı", "LY-8797" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1061,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 437000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 579.0, "Ağrı", 8580m, 33.0, 1, "Bitlis - Ağrı Paletli Gıda Kolileri", "LY-3672" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1062,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 139000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 166.0, "Edirne", 1502m, 13.0, 1, "Bitlis - Edirne Plastik Hammadde Sevkiyatı", "LY-4858" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1063,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 292000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 714.0, "Konya", 10217m, 33.0, "Bitlis - Konya Mobilya ve Ev Eşyası Taşıma", "LY-1321" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1064,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 454000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 598.0, "Erzincan", 3824m, 12.0, "Bitlis - Erzincan Mobilya ve Ev Eşyası Taşıma", "LY-3083" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1065,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 43000m, 250.0, "Muğla", 1643m, 11.0, 1, "Bolu - Muğla Makine Teçhizat Parçaları", "LY-1860" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1066,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 122000m, 263.0, "Batman", 3988m, 32.0, 2, "Bolu - Batman Karton Kutu Ambalajları", "LY-2461" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1067,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 219000m, 504.0, "Osmaniye", 3743m, 15.0, "Bolu - Osmaniye Tekstil Ürünleri Sevkiyatı", "LY-7281" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1068,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 352000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 410.0, "Adıyaman", 3312m, 15.0, "Bolu - Adıyaman Makine Teçhizat Parçaları", "LY-1410" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1069,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 485000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 492.0, "Afyonkarahisar", 5315m, 22.0, 3, "Bolu - Afyonkarahisar Oto Yedek Parça Nakliyesi", "LY-6600" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1070,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 204000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 167.0, "Ankara", 1639m, 14.0, 2, "Burdur - Ankara Plastik Hammadde Sevkiyatı", "LY-8415" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1071,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 23000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 240.0, "Mersin", 3499m, 31.0, 3, "Burdur - Mersin Beyaz Eşya Dağıtımı", "LY-6296" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1072,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 481000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 264.0, "Muğla", 4043m, 1, "Burdur - Muğla İnşaat Malzemeleri Götürme", "LY-5120" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1073,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 475000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 106.0, "Sakarya", 1950m, 23.0, 3, "Burdur - Sakarya Karton Kutu Ambalajları", "LY-2026" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1074,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 277000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 637.0, "Malatya", 9440m, 34.0, 2, "Burdur - Malatya Plastik Hammadde Sevkiyatı", "LY-6701" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1075,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 477000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 122.0, "Kars", 2197m, 25.0, "Bursa - Kars İnşaat Malzemeleri Götürme", "LY-1791" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1076,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 405000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 187.0, 3373m, 33.0, 3, "Bursa - Aydın Makine Teçhizat Parçaları", "LY-6967" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1077,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 56000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 488.0, "Denizli", 4655m, 21.0, 3, "Bursa - Denizli Karton Kutu Ambalajları", "LY-7019" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1078,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 77000m, 144.0, "Uşak", 2363m, 31.0, 3, "Bursa - Uşak Beyaz Eşya Dağıtımı", "LY-1331" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1079,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 86000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 697.0, "Aydın", 5047m, 16.0, "Bursa - Aydın Plastik Hammadde Sevkiyatı", "LY-1881" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1080,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 499000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 725.0, "Sivas", 9119m, 28.0, "Çanakkale - Sivas Karton Kutu Ambalajları", "LY-9334" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1081,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 421000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 405.0, "Kastamonu", 3351m, 15.0, 1, "Çanakkale - Kastamonu Tekstil Ürünleri Sevkiyatı", "LY-7765" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1082,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 194000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 933.0, "Nevşehir", 7412m, 18.0, 1, "Çanakkale - Nevşehir Tarım Gübresi ve Tohum", "LY-8914" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1083,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 391000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 188.0, "Mardin", 1718m, 11.0, 3, "Çanakkale - Mardin Karton Kutu Ambalajları", "LY-2833" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1084,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 73000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 764.0, "Çorum", 7602m, 23.0, 1, "Çanakkale - Çorum Tarım Gübresi ve Tohum", "LY-1316" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1085,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 365000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 669.0, "Elazığ", 4611m, 14.0, 2, "Çankırı - Elazığ Plastik Hammadde Sevkiyatı", "LY-2057" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1086,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 247000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 460.0, "Gümüşhane", 6635m, 2, "Çankırı - Gümüşhane Karton Kutu Ambalajları", "LY-8393" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1087,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 62000m, 604.0, "Siirt", 6119m, 23.0, "Çankırı - Siirt Paletli Gıda Kolileri", "LY-9724" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1088,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 499000m, 669.0, "Kocaeli", 6619m, 21.0, 1, "Çankırı - Kocaeli Paletli Gıda Kolileri", "LY-6433" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1089,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 94000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 427.0, "İstanbul", 3839m, 19.0, "Çankırı - İstanbul Beyaz Eşya Dağıtımı", "LY-8669" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1090,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 193000m, 363.0, "Isparta", 5194m, 31.0, "Çorum - Isparta Tekstil Ürünleri Sevkiyatı", "LY-4175" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1091,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 499000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 258.0, "Sivas", 4198m, 31.0, 2, "Çorum - Sivas Plastik Hammadde Sevkiyatı", "LY-2851" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1092,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 334000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 400.0, "Diyarbakır", 2914m, 13.0, "Çorum - Diyarbakır Tekstil Ürünleri Sevkiyatı", "LY-8448" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1093,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 459000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 548.0, "Tunceli", 6001m, 23.0, "Çorum - Tunceli Makine Teçhizat Parçaları", "LY-8205" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1094,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 212000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 215.0, "Siirt", 2862m, 25.0, "Çorum - Siirt Makine Teçhizat Parçaları", "LY-6429" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1095,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 347000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 454.0, "Kastamonu", 6658m, 32.0, 1, "Denizli - Kastamonu Tarım Gübresi ve Tohum", "LY-8132" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1096,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 395000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 720.0, "Hakkari", 4639m, 13.0, "Denizli - Hakkari Oto Yedek Parça Nakliyesi", "LY-5254" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1097,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 435000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 774.0, "Manisa", 4960m, 13.0, 2, "Denizli - Manisa Karton Kutu Ambalajları", "LY-4657" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1098,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 127000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 824.0, "Bayburt", 8867m, 25.0, "Denizli - Bayburt Beyaz Eşya Dağıtımı", "LY-1086" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1099,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 342000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 164.0, "Muğla", 2285m, 22.0, "Denizli - Muğla Oto Yedek Parça Nakliyesi", "LY-3620" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1100,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 192000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 867.0, "Konya", 6241m, 16.0, 3, "Diyarbakır - Konya Oto Yedek Parça Nakliyesi", "LY-6005" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1101,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 76000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 599.0, "Elazığ", 3212m, 11.0, 2, "Diyarbakır - Elazığ Plastik Hammadde Sevkiyatı", "LY-3702" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1102,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 303000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 216.0, "Bartın", 2013m, 14.0, 1, "Diyarbakır - Bartın Tarım Gübresi ve Tohum", "LY-1220" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1103,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 449000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 851.0, "Hakkari", 4353m, 10.0, 2, "Diyarbakır - Hakkari Tekstil Ürünleri Sevkiyatı", "LY-5726" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1104,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 160000m, 514.0, "Aksaray", 2922m, 11.0, 1, "Diyarbakır - Aksaray Makine Teçhizat Parçaları", "LY-4334" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1105,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 407000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 496.0, "Giresun", 5073m, 21.0, "Edirne - Giresun Mobilya ve Ev Eşyası Taşıma", "LY-6102" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1106,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 184000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 882.0, "Batman", 10915m, 29.0, 2, "Edirne - Batman Karton Kutu Ambalajları", "LY-7637" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1107,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 29000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 423.0, "Uşak", 3067m, 15.0, "Edirne - Uşak Paletli Gıda Kolileri", "LY-9580" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1108,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 116000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 626.0, "Batman", 3120m, 10.0, 3, "Edirne - Batman Karton Kutu Ambalajları", "LY-5441" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1109,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 289000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 572.0, "Kilis", 3077m, 10.0, 2, "Edirne - Kilis Tarım Gübresi ve Tohum", "LY-8024" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1110,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 160000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 518.0, "Tokat", 7705m, 34.0, 2, "Elazığ - Tokat İnşaat Malzemeleri Götürme", "LY-9701" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1111,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 169000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 370.0, "Çankırı", 2149m, 10.0, 2, "Elazığ - Çankırı Makine Teçhizat Parçaları", "LY-4876" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1112,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 20000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 679.0, "Bingöl", 3779m, 12.0, 3, "Elazığ - Bingöl Tekstil Ürünleri Sevkiyatı", "LY-9388" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1113,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 205000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 288.0, "Samsun", 4161m, 30.0, "Elazığ - Samsun Plastik Hammadde Sevkiyatı", "LY-4757" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1114,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 320000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 599.0, "Karaman", 4414m, 15.0, 3, "Elazığ - Karaman Tarım Gübresi ve Tohum", "LY-3250" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1115,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 55000m, 657.0, "Manisa", 9227m, 33.0, 3, "Erzincan - Manisa Paletli Gıda Kolileri", "LY-7804" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1116,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 465000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 726.0, "Kütahya", 8515m, 26.0, "Erzincan - Kütahya Mobilya ve Ev Eşyası Taşıma", "LY-6808" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1117,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 181000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 808.0, "Bursa", 5529m, 15.0, 3, "Erzincan - Bursa Oto Yedek Parça Nakliyesi", "LY-8194" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1118,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 118000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 540.0, "Tekirdağ", 7098m, 30.0, "Erzincan - Tekirdağ Plastik Hammadde Sevkiyatı", "LY-6955" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1119,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 331000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 606.0, "Elazığ", 5194m, 18.0, 2, "Erzincan - Elazığ İnşaat Malzemeleri Götürme", "LY-9916" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1120,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 387000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 889.0, "Bayburt", 9066m, 23.0, 2, "Erzurum - Bayburt Oto Yedek Parça Nakliyesi", "LY-6272" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1121,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 342000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 279.0, "Osmaniye", 4413m, 32.0, "Erzurum - Osmaniye Paletli Gıda Kolileri", "LY-2330" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1122,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 51000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 536.0, "Eskişehir", 8055m, 35.0, 2, "Erzurum - Eskişehir Paletli Gıda Kolileri", "LY-1447" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1123,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 386000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 369.0, "Manisa", 5462m, 31.0, "Erzurum - Manisa Beyaz Eşya Dağıtımı", "LY-8837" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1124,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 56000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 184.0, "Karabük", 2322m, 24.0, 2, "Erzurum - Karabük Oto Yedek Parça Nakliyesi", "LY-5053" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1125,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 182000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 940.0, "Nevşehir", 6322m, 15.0, 2, "Eskişehir - Nevşehir Paletli Gıda Kolileri", "LY-7032" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1126,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 297000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 833.0, "Bayburt", 4795m, 12.0, 2, "Eskişehir - Bayburt Paletli Gıda Kolileri", "LY-1381" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1127,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 76000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 482.0, "Bingöl", 2697m, 3, "Eskişehir - Bingöl Oto Yedek Parça Nakliyesi", "LY-2704" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1128,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 398000m, 307.0, "Trabzon", 4828m, 32.0, "Eskişehir - Trabzon Makine Teçhizat Parçaları", "LY-3868" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1129,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 359000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 274.0, "Çorum", 4585m, 34.0, 2, "Eskişehir - Çorum Paletli Gıda Kolileri", "LY-7982" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1130,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 194000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 424.0, "Diyarbakır", 4934m, 25.0, 2, "Gaziantep - Diyarbakır Beyaz Eşya Dağıtımı", "LY-7646" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1131,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 485000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 518.0, "Gümüşhane", 3057m, 10.0, "Gaziantep - Gümüşhane Paletli Gıda Kolileri", "LY-5673" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1132,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 75000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 151.0, "Erzincan", 2206m, 27.0, 3, "Gaziantep - Erzincan Paletli Gıda Kolileri", "LY-5241" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1133,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 465000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 471.0, "Bitlis", 7371m, 34.0, 3, "Gaziantep - Bitlis Oto Yedek Parça Nakliyesi", "LY-7470" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1134,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 155000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 431.0, "Malatya", 6172m, 32.0, 3, "Gaziantep - Malatya Mobilya ve Ev Eşyası Taşıma", "LY-4762" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1135,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 389000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 319.0, "Amasya", 4845m, 31.0, "Giresun - Amasya Makine Teçhizat Parçaları", "LY-1851" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1136,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 228000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 217.0, "Gaziantep", 2898m, 25.0, 1, "Giresun - Gaziantep Makine Teçhizat Parçaları", "LY-9582" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1137,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 405000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 463.0, "Ağrı", 6276m, 29.0, 3, "Giresun - Ağrı Plastik Hammadde Sevkiyatı", "LY-5115" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1138,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 132000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 109.0, "Kahramanmaraş", 1460m, 1, "Giresun - Kahramanmaraş İnşaat Malzemeleri Götürme", "LY-1703" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1139,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 495000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 426.0, "Düzce", 5766m, 28.0, "Giresun - Düzce Plastik Hammadde Sevkiyatı", "LY-9094" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1140,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 480000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 182.0, "Çorum", 1999m, 14.0, 2, "Gümüşhane - Çorum Karton Kutu Ambalajları", "LY-9370" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1141,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 111000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 313.0, 3491m, 23.0, "Gümüşhane - Ankara Oto Yedek Parça Nakliyesi", "LY-2316" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1142,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 111000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 182.0, "Giresun", 3159m, 35.0, "Gümüşhane - Giresun Paletli Gıda Kolileri", "LY-7821" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1143,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 80000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 144.0, "Muğla", 1444m, 15.0, 1, "Gümüşhane - Muğla Tarım Gübresi ve Tohum", "LY-2263" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1144,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 333000m, 612.0, 6219m, 22.0, "LY-3524" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1145,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 239000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 788.0, "Sinop", 11771m, 35.0, "Hakkari - Sinop Tekstil Ürünleri Sevkiyatı", "LY-2390" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1146,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 23000m, 134.0, "Muğla", 1059m, 10.0, "Hakkari - Muğla Karton Kutu Ambalajları", "LY-6044" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1147,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 346000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 899.0, "Uşak", 13072m, 34.0, "Hakkari - Uşak Oto Yedek Parça Nakliyesi", "LY-8834" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1148,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 395000m, 682.0, "Muş", 3623m, 10.0, 3, "Hakkari - Muş Tarım Gübresi ve Tohum", "LY-9991" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1149,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 84000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 206.0, "Muğla", 3303m, 33.0, "Hakkari - Muğla Paletli Gıda Kolileri", "LY-5320" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1150,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 367000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 920.0, "Gümüşhane", 7491m, 18.0, 2, "Hatay - Gümüşhane Beyaz Eşya Dağıtımı", "LY-6532" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1151,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 370000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 113.0, "Batman", 2090m, 27.0, "Hatay - Batman Oto Yedek Parça Nakliyesi", "LY-9601" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1152,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 116000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 786.0, "Van", 5646m, 16.0, "Hatay - Van Oto Yedek Parça Nakliyesi", "LY-6174" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1153,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 397000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 649.0, "Kilis", 5829m, 19.0, "Hatay - Kilis Plastik Hammadde Sevkiyatı", "LY-5935" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1154,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 250000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 842.0, "Çanakkale", 5802m, "Hatay - Çanakkale Paletli Gıda Kolileri", "LY-4964" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1155,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 322000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 825.0, "Edirne", 8742m, 24.0, 2, "Isparta - Edirne Plastik Hammadde Sevkiyatı", "LY-3168" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1156,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 55000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 228.0, "Karaman", 2105m, 17.0, 3, "Isparta - Karaman Makine Teçhizat Parçaları", "LY-4262" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1157,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 42000m, 185.0, "Kilis", 1948m, "Isparta - Kilis Tekstil Ürünleri Sevkiyatı", "LY-3915" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1158,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 52000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 369.0, "Elazığ", 3356m, 19.0, "Isparta - Elazığ Oto Yedek Parça Nakliyesi", "LY-6023" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1159,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 380000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 393.0, "Kırıkkale", 2609m, 11.0, 1, "Isparta - Kırıkkale Mobilya ve Ev Eşyası Taşıma", "LY-3730" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1160,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 152000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 212.0, "Niğde", 3620m, 35.0, 2, "Mersin - Niğde Tekstil Ürünleri Sevkiyatı", "LY-5453" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1161,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 289000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 281.0, "Nevşehir", 2700m, 17.0, 1, "Mersin - Nevşehir Oto Yedek Parça Nakliyesi", "LY-4696" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1162,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 41000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 768.0, "Eskişehir", 6685m, 20.0, "Mersin - Eskişehir İnşaat Malzemeleri Götürme", "LY-3056" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1163,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 487000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 289.0, "Iğdır", 2143m, 10.0, "Mersin - Iğdır Oto Yedek Parça Nakliyesi", "LY-7745" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1164,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 155000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 100.0, "Balıkesir", 2015m, 34.0, 3, "Mersin - Balıkesir Oto Yedek Parça Nakliyesi", "LY-7055" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1165,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 385000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 359.0, "Kars", 2608m, 12.0, 1, "İstanbul - Kars Plastik Hammadde Sevkiyatı", "LY-6947" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1166,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 319000m, 590.0, "Osmaniye", 5067m, 18.0, 1, "İstanbul - Osmaniye Paletli Gıda Kolileri", "LY-3560" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1167,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 25000m, 640.0, "Giresun", 3853m, 13.0, 3, "İstanbul - Giresun Beyaz Eşya Dağıtımı", "LY-4805" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1168,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 105000m, 122.0, "Düzce", 2264m, 34.0, 1, "İstanbul - Düzce Paletli Gıda Kolileri", "LY-7804" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1169,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 171000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 242.0, "Iğdır", 1639m, 10.0, 2, "İstanbul - Iğdır Mobilya ve Ev Eşyası Taşıma", "LY-6679" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1170,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 394000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 516.0, "Bayburt", 7705m, 33.0, 1, "İzmir - Bayburt Beyaz Eşya Dağıtımı", "LY-6052" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1171,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 298000m, 464.0, "Çanakkale", 4324m, 19.0, "İzmir - Çanakkale Karton Kutu Ambalajları", "LY-5393" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1172,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 126000m, 781.0, "Muğla", 7186m, 21.0, 2, "İzmir - Muğla İnşaat Malzemeleri Götürme", "LY-2206" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1173,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 367000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 119.0, "Edirne", 1486m, 13.0, 1, "İzmir - Edirne İnşaat Malzemeleri Götürme", "LY-3148" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1174,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 193000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 279.0, "Kırşehir", 4041m, 30.0, 1, "İzmir - Kırşehir Beyaz Eşya Dağıtımı", "LY-8149" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1175,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 124000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 397.0, "Kahramanmaraş", 4118m, 22.0, 1, "Kars - Kahramanmaraş Tekstil Ürünleri Sevkiyatı", "LY-2501" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1176,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 308000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 634.0, "Trabzon", 8923m, 32.0, 2, "Kars - Trabzon Tekstil Ürünleri Sevkiyatı", "LY-7328" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1177,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 37000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 513.0, "Şırnak", 3410m, 14.0, 1, "Kars - Şırnak Mobilya ve Ev Eşyası Taşıma", "LY-8117" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1178,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 427000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 291.0, "Aksaray", 3837m, 25.0, "Kars - Aksaray Tarım Gübresi ve Tohum", "LY-6977" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1179,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 84000m, 139.0, "Niğde", 2530m, 35.0, 3, "Kars - Niğde Tekstil Ürünleri Sevkiyatı", "LY-6340" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1180,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 367000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 854.0, "Ankara", 10090m, 27.0, "Kastamonu - Ankara Beyaz Eşya Dağıtımı", "LY-2683" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1181,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 52000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 551.0, "Bitlis", 3197m, 12.0, 2, "Kastamonu - Bitlis Oto Yedek Parça Nakliyesi", "LY-9582" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1182,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 41000m, 860.0, "Denizli", 8109m, 22.0, "Kastamonu - Denizli Tarım Gübresi ve Tohum", "LY-8510" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1183,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 57000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 746.0, "Manisa", 7719m, 2, "Kastamonu - Manisa Plastik Hammadde Sevkiyatı", "LY-8172" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1184,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 58000m, 188.0, "Nevşehir", 1912m, 18.0, 3, "Kastamonu - Nevşehir Makine Teçhizat Parçaları", "LY-8538" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1185,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 376000m, 569.0, "Samsun", 7021m, 27.0, 2, "Kayseri - Samsun Makine Teçhizat Parçaları", "LY-3236" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1186,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 396000m, 115.0, "Balıkesir", 1678m, 17.0, "Kayseri - Balıkesir Tekstil Ürünleri Sevkiyatı", "LY-5447" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1187,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 238000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 168.0, "Tunceli", 3090m, 1, "Kayseri - Tunceli Beyaz Eşya Dağıtımı", "LY-2068" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1188,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 277000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 235.0, "Niğde", 1905m, 12.0, "Kayseri - Niğde Karton Kutu Ambalajları", "LY-6602" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1189,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 288000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 789.0, "Kilis", 6784m, 19.0, 3, "Kayseri - Kilis Oto Yedek Parça Nakliyesi", "LY-7306" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1190,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 139000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 803.0, "Niğde", 9311m, 27.0, 1, "Kırklareli - Niğde İnşaat Malzemeleri Götürme", "LY-7786" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1191,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 81000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 290.0, "Bitlis", 2553m, 17.0, 2, "Kırklareli - Bitlis Oto Yedek Parça Nakliyesi", "LY-5770" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1192,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 268000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 596.0, "Nevşehir", 6013m, 22.0, 1, "Kırklareli - Nevşehir Karton Kutu Ambalajları", "LY-8955" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1193,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 348000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 274.0, "Ankara", 2273m, 13.0, 2, "Kırklareli - Ankara Beyaz Eşya Dağıtımı", "LY-7494" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1194,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 397000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 416.0, "Bolu", 6555m, 34.0, "Kırklareli - Bolu Karton Kutu Ambalajları", "LY-6379" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1195,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 53000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 814.0, "Kilis", 7065m, 20.0, "Kırşehir - Kilis İnşaat Malzemeleri Götürme", "LY-4105" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1196,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 444000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 189.0, "Erzincan", 3212m, 30.0, 2, "Kırşehir - Erzincan İnşaat Malzemeleri Götürme", "LY-5102" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1197,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 386000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 497.0, "Muş", 6452m, 28.0, "Kırşehir - Muş Plastik Hammadde Sevkiyatı", "LY-9745" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1198,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 365000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 798.0, "Bitlis", 8526m, 24.0, 2, "Kırşehir - Bitlis Mobilya ve Ev Eşyası Taşıma", "LY-8337" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1199,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 384000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 100.0, "Edirne", 2084m, 30.0, 2, "Kırşehir - Edirne Paletli Gıda Kolileri", "LY-5439" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1200,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 97000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 877.0, "Elazığ", 9367m, 25.0, 2, "Kocaeli - Elazığ Oto Yedek Parça Nakliyesi", "LY-2167" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1201,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 56000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 520.0, "Çankırı", 6588m, 29.0, 2, "Kocaeli - Çankırı Oto Yedek Parça Nakliyesi", "LY-5706" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1202,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 251000m, 609.0, "Mardin", 5379m, 19.0, 2, "Kocaeli - Mardin İnşaat Malzemeleri Götürme", "LY-5098" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1203,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 180000m, 946.0, "Bayburt", 9762m, 24.0, 3, "Kocaeli - Bayburt Tekstil Ürünleri Sevkiyatı", "LY-7196" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1204,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 257000m, 662.0, "Mardin", 3405m, 10.0, "Kocaeli - Mardin İnşaat Malzemeleri Götürme", "LY-6429" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1205,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 269000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 886.0, "Malatya", 7148m, 18.0, "Konya - Malatya Plastik Hammadde Sevkiyatı", "LY-9303" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1206,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 157000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 780.0, "Bingöl", 5961m, 17.0, "Konya - Bingöl Tekstil Ürünleri Sevkiyatı", "LY-6037" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1207,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 345000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 846.0, "Balıkesir", 9643m, 26.0, 2, "Konya - Balıkesir Karton Kutu Ambalajları", "LY-5332" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1208,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 43000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 165.0, "Kütahya", 1995m, 22.0, 3, "Konya - Kütahya Tekstil Ürünleri Sevkiyatı", "LY-8390" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1209,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 467000m, 378.0, "İzmir", 4596m, 24.0, 2, "Konya - İzmir Makine Teçhizat Parçaları", "LY-4201" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1210,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 463000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 343.0, "Kilis", 5353m, 32.0, 1, "Kütahya - Kilis Beyaz Eşya Dağıtımı", "LY-6500" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1211,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 298000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 828.0, 7091m, 19.0, 2, "Kütahya - Bartın Makine Teçhizat Parçaları", "LY-4299" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1212,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 275000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 136.0, "Artvin", 1645m, 16.0, 3, "Kütahya - Artvin Beyaz Eşya Dağıtımı", "LY-3091" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1213,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 324000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 466.0, "Burdur", 6043m, 28.0, 1, "Kütahya - Burdur Tarım Gübresi ve Tohum", "LY-2753" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1214,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 440000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 137.0, "Muş", 2803m, 34.0, "Kütahya - Muş İnşaat Malzemeleri Götürme", "LY-9680" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1215,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 95000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 784.0, "Bayburt", 8749m, 26.0, 1, "Malatya - Bayburt Tekstil Ürünleri Sevkiyatı", "LY-3364" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1216,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 190000m, 741.0, "Tokat", 10175m, 32.0, "Malatya - Tokat İnşaat Malzemeleri Götürme", "LY-4851" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1217,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 359000m, 289.0, "Bursa", 2362m, 13.0, "Malatya - Bursa Karton Kutu Ambalajları", "LY-7918" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1218,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 460000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 285.0, "Kahramanmaraş", 4722m, 33.0, 3, "Malatya - Kahramanmaraş Tekstil Ürünleri Sevkiyatı", "LY-2691" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1219,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 322000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 122.0, "Ardahan", 1749m, 19.0, 1, "Malatya - Ardahan Makine Teçhizat Parçaları", "LY-3557" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1220,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 332000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 307.0, "Bilecik", 2183m, 11.0, 1, "Manisa - Bilecik Karton Kutu Ambalajları", "LY-6874" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1221,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 450000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 219.0, "Amasya", 2439m, 17.0, "Manisa - Amasya İnşaat Malzemeleri Götürme", "LY-9669" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1222,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 429000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 800.0, "Yalova", 4449m, 11.0, 3, "Manisa - Yalova Tarım Gübresi ve Tohum", "LY-7279" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1223,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 99000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 580.0, "Yalova", 3383m, 12.0, 3, "Manisa - Yalova Oto Yedek Parça Nakliyesi", "LY-6702" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1224,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 104000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 874.0, "Tunceli", 12490m, 34.0, 3, "Manisa - Tunceli Tekstil Ürünleri Sevkiyatı", "LY-3948" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1225,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 38000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 119.0, "Balıkesir", 1776m, 26.0, "Kahramanmaraş - Balıkesir Paletli Gıda Kolileri", "LY-1696" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1226,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 134000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 341.0, "Hatay", 2953m, 17.0, 3, "Kahramanmaraş - Hatay Beyaz Eşya Dağıtımı", "LY-1694" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1227,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 64000m, 857.0, "Niğde", 8106m, 22.0, "Kahramanmaraş - Niğde Karton Kutu Ambalajları", "LY-5760" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1228,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 37000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 757.0, "Antalya", 10832m, 34.0, 2, "Kahramanmaraş - Antalya Plastik Hammadde Sevkiyatı", "LY-7839" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1229,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 485000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 868.0, "Tunceli", 6193m, 15.0, 1, "Kahramanmaraş - Tunceli Plastik Hammadde Sevkiyatı", "LY-9380" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1230,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 211000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 538.0, "Diyarbakır", 3509m, 13.0, "Mardin - Diyarbakır Tarım Gübresi ve Tohum", "LY-6854" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1231,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 445000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 123.0, "Muğla", 1978m, 21.0, 1, "Mardin - Muğla Tarım Gübresi ve Tohum", "LY-8465" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1232,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 324000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 384.0, "Malatya", 5125m, 28.0, 2, "Mardin - Malatya Tekstil Ürünleri Sevkiyatı", "LY-6001" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1233,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 433000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 661.0, "Kırıkkale", 7807m, 26.0, 2, "Mardin - Kırıkkale Plastik Hammadde Sevkiyatı", "LY-5826" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1234,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 72000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 683.0, "Bartın", 9588m, 1, "Mardin - Bartın Makine Teçhizat Parçaları", "LY-2594" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1235,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 214000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 846.0, "Denizli", 9512m, 26.0, "Muğla - Denizli Mobilya ve Ev Eşyası Taşıma", "LY-2983" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1236,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 84000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 624.0, "Ordu", 3330m, 11.0, 2, "Muğla - Ordu İnşaat Malzemeleri Götürme", "LY-1714" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1237,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 389000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 716.0, 8622m, 27.0, 2, "Muğla - Van Karton Kutu Ambalajları", "LY-2680" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1238,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 399000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 460.0, "Isparta", 3843m, 16.0, "Muğla - Isparta Oto Yedek Parça Nakliyesi", "LY-6761" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1239,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 125000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 492.0, "Kütahya", 6529m, 30.0, "Muğla - Kütahya Paletli Gıda Kolileri", "LY-7895" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1240,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 314000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 757.0, "Kilis", 5053m, 14.0, 2, "Muş - Kilis Tekstil Ürünleri Sevkiyatı", "LY-4690" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1241,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 469000m, 506.0, "Ağrı", 5017m, 20.0, "Muş - Ağrı Plastik Hammadde Sevkiyatı", "LY-9175" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1242,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 377000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 821.0, "Gümüşhane", 5475m, 14.0, "Muş - Gümüşhane Tarım Gübresi ve Tohum", "LY-2114" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1243,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 294000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 589.0, "Çanakkale", 4092m, 14.0, 3, "Muş - Çanakkale Karton Kutu Ambalajları", "LY-8485" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1244,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 132000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 760.0, "Kilis", 11272m, 35.0, 3, "Muş - Kilis Tekstil Ürünleri Sevkiyatı", "LY-3103" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1245,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 69000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 599.0, "Elazığ", 8236m, 32.0, 3, "Nevşehir - Elazığ Plastik Hammadde Sevkiyatı", "LY-7434" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1246,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 165000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 294.0, "Tokat", 4546m, 33.0, "Nevşehir - Tokat İnşaat Malzemeleri Götürme", "LY-7584" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1247,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 350000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 501.0, "Erzincan", 6862m, 30.0, 1, "Nevşehir - Erzincan Karton Kutu Ambalajları", "LY-3794" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1248,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 102000m, 199.0, "Aksaray", 3388m, 35.0, 3, "Nevşehir - Aksaray Plastik Hammadde Sevkiyatı", "LY-4126" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1249,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 265000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 182.0, "Tunceli", 2658m, 26.0, "Nevşehir - Tunceli Makine Teçhizat Parçaları", "LY-1602" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1250,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 319000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 666.0, "Kocaeli", 8811m, 30.0, 3, "Niğde - Kocaeli Paletli Gıda Kolileri", "LY-6031" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1251,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 64000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 602.0, "Isparta", 5621m, 21.0, 3, "Niğde - Isparta Plastik Hammadde Sevkiyatı", "LY-5404" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1252,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 159000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 575.0, "Iğdır", 4799m, 18.0, "Niğde - Iğdır Plastik Hammadde Sevkiyatı", "LY-6737" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1253,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 400000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 760.0, "Bursa", 5460m, 15.0, 3, "Niğde - Bursa Tekstil Ürünleri Sevkiyatı", "LY-7957" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1254,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 435000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 278.0, "Giresun", 2825m, 17.0, 3, "Niğde - Giresun İnşaat Malzemeleri Götürme", "LY-3931" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1255,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 23000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 664.0, "Artvin", 4773m, 16.0, 3, "Ordu - Artvin Karton Kutu Ambalajları", "LY-8816" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1256,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 91000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 277.0, "Edirne", 1810m, 11.0, 3, "Ordu - Edirne Oto Yedek Parça Nakliyesi", "LY-9882" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1257,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 202000m, 604.0, "Malatya", 7467m, 28.0, 3, "Ordu - Malatya Tekstil Ürünleri Sevkiyatı", "LY-2614" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1258,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 499000m, 153.0, "Eskişehir", 2468m, 24.0, 2, "Ordu - Eskişehir Oto Yedek Parça Nakliyesi", "LY-7435" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1259,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 245000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 261.0, "Hakkari", 3877m, 30.0, 2, "Ordu - Hakkari Tekstil Ürünleri Sevkiyatı", "LY-9080" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1260,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 56000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 264.0, "Mardin", 2668m, 20.0, "Rize - Mardin Tekstil Ürünleri Sevkiyatı", "LY-3961" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1261,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 119000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 701.0, 8751m, 29.0, 1, "Rize - Amasya Tarım Gübresi ve Tohum", "LY-1619" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1262,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 409000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 331.0, "Iğdır", 4881m, 30.0, 1, "Rize - Iğdır Paletli Gıda Kolileri", "LY-2109" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1263,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 346000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 156.0, "Düzce", 1720m, 14.0, "Rize - Düzce Tekstil Ürünleri Sevkiyatı", "LY-4742" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1264,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 294000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 308.0, "Şırnak", 4120m, 27.0, 2, "Rize - Şırnak Tekstil Ürünleri Sevkiyatı", "LY-8452" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1265,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 491000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 237.0, "Çorum", 2318m, 14.0, 3, "Sakarya - Çorum İnşaat Malzemeleri Götürme", "LY-6635" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1266,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 156000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 746.0, "Uşak", 10802m, 34.0, 3, "Sakarya - Uşak Oto Yedek Parça Nakliyesi", "LY-6061" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1267,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 362000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 421.0, "Malatya", 6419m, 33.0, 3, "Sakarya - Malatya Plastik Hammadde Sevkiyatı", "LY-6297" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1268,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 349000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 410.0, "Balıkesir", 5933m, 31.0, "Sakarya - Balıkesir Mobilya ve Ev Eşyası Taşıma", "LY-9960" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1269,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 432000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 110.0, "Niğde", 1416m, 11.0, 2, "Sakarya - Niğde Paletli Gıda Kolileri", "LY-7412" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1270,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 232000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 616.0, "Amasya", 5660m, 20.0, 2, "Samsun - Amasya Tarım Gübresi ve Tohum", "LY-9942" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1271,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 290000m, 543.0, "Balıkesir", 5351m, 21.0, 1, "Samsun - Balıkesir Mobilya ve Ev Eşyası Taşıma", "LY-1904" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1272,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 255000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 181.0, "Van", 2348m, 22.0, 1, "Samsun - Van Tarım Gübresi ve Tohum", "LY-6181" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1273,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 357000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 679.0, "Bursa", 9820m, 33.0, "Samsun - Bursa Tekstil Ürünleri Sevkiyatı", "LY-7881" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1274,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 477000m, 673.0, "İzmir", 10399m, 35.0, 3, "Samsun - İzmir Oto Yedek Parça Nakliyesi", "LY-9852" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1275,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 344000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 155.0, "Konya", 2828m, 32.0, "Siirt - Konya İnşaat Malzemeleri Götürme", "LY-6452" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1276,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 284000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 582.0, "Bolu", 5673m, 21.0, 1, "Siirt - Bolu Karton Kutu Ambalajları", "LY-6828" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1277,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 235000m, 452.0, "Malatya", 3447m, 15.0, "Siirt - Malatya İnşaat Malzemeleri Götürme", "LY-1766" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1278,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 118000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 818.0, "Edirne", 5853m, 16.0, 2, "Siirt - Edirne Oto Yedek Parça Nakliyesi", "LY-7957" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1279,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 287000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 535.0, "Sinop", 4639m, 18.0, 3, "Siirt - Sinop Karton Kutu Ambalajları", "LY-8031" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1280,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 118000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 843.0, "Kahramanmaraş", 8374m, 23.0, 2, "Sinop - Kahramanmaraş Oto Yedek Parça Nakliyesi", "LY-5088" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1281,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 243000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 156.0, "Edirne", 2053m, 21.0, 1, "Sinop - Edirne Oto Yedek Parça Nakliyesi", "LY-6984" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1282,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 127000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 919.0, "Hatay", 4671m, 11.0, 1, "Sinop - Hatay İnşaat Malzemeleri Götürme", "LY-6730" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1283,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 263000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 930.0, "Osmaniye", 10435m, 26.0, 1, "Sinop - Osmaniye Tarım Gübresi ve Tohum", "LY-8756" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1284,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 39000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 150.0, "Bartın", 1439m, 15.0, 1, "Sinop - Bartın Tekstil Ürünleri Sevkiyatı", "LY-2026" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1285,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 53000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 294.0, "Amasya", 2435m, 16.0, "Sivas - Amasya Paletli Gıda Kolileri", "LY-1118" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1286,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 87000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 384.0, "Bilecik", 4888m, 28.0, "Sivas - Bilecik Makine Teçhizat Parçaları", "LY-9931" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1287,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 319000m, 742.0, "Iğdır", 3787m, 10.0, "Sivas - Iğdır İnşaat Malzemeleri Götürme", "LY-1286" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1288,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 27000m, 380.0, "Malatya", 4783m, 28.0, 2, "Sivas - Malatya Tekstil Ürünleri Sevkiyatı", "LY-3011" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1289,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 277000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 871.0, "Batman", 7397m, 19.0, "Sivas - Batman Tekstil Ürünleri Sevkiyatı", "LY-1573" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1290,
                columns: new[] { "CargoImageUrl", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 748.0, "Konya", 4525m, 13.0, 3, "Tekirdağ - Konya Oto Yedek Parça Nakliyesi", "LY-7334" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1291,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 435000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 470.0, "Sinop", 7327m, 34.0, 1, "Tekirdağ - Sinop Beyaz Eşya Dağıtımı", "LY-4658" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1292,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 329000m, 198.0, "Artvin", 3126m, 29.0, 2, "Tekirdağ - Artvin Plastik Hammadde Sevkiyatı", "LY-2699" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1293,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 479000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 433.0, "Balıkesir", 3404m, 14.0, 2, "Tekirdağ - Balıkesir Oto Yedek Parça Nakliyesi", "LY-5900" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1294,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 254000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 352.0, "Kırklareli", 3429m, 19.0, "Tekirdağ - Kırklareli Tarım Gübresi ve Tohum", "LY-9754" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1295,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 389000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 112.0, "Kastamonu", 2367m, 33.0, 1, "Tokat - Kastamonu Paletli Gıda Kolileri", "LY-9349" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1296,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 229000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 836.0, "Uşak", 6414m, 17.0, "Tokat - Uşak Karton Kutu Ambalajları", "LY-5064" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1297,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 383000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 734.0, "Bolu", 9985m, 31.0, 3, "Tokat - Bolu Mobilya ve Ev Eşyası Taşıma", "LY-1282" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1298,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 430000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 609.0, "Gaziantep", 7507m, 27.0, "Tokat - Gaziantep Mobilya ve Ev Eşyası Taşıma", "LY-2166" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1299,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 37000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 398.0, "Bursa", 3562m, 19.0, 2, "Tokat - Bursa Plastik Hammadde Sevkiyatı", "LY-1728" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1300,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 294000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 129.0, "Kilis", 2136m, 26.0, 1, "Trabzon - Kilis Makine Teçhizat Parçaları", "LY-5807" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1301,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 220000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 687.0, "Karabük", 3468m, 10.0, 2, "Trabzon - Karabük Tekstil Ürünleri Sevkiyatı", "LY-1358" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1302,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 405000m, 891.0, 13023m, 34.0, 2, "Trabzon - Elazığ Beyaz Eşya Dağıtımı", "LY-9656" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1303,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 91000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 211.0, "Karabük", 1773m, 14.0, "Trabzon - Karabük Makine Teçhizat Parçaları", "LY-4120" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1304,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 346000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 741.0, "Kırklareli", 5588m, 16.0, 1, "Trabzon - Kırklareli Mobilya ve Ev Eşyası Taşıma", "LY-9588" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1305,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 191000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 761.0, "Bitlis", 10736m, 33.0, 3, "Tunceli - Bitlis Beyaz Eşya Dağıtımı", "LY-9813" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1306,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 481000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 534.0, "Bolu", 3544m, 12.0, 2, "Tunceli - Bolu Tarım Gübresi ve Tohum", "LY-4629" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1307,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 319000m, 263.0, "Yozgat", 2081m, 12.0, 1, "Tunceli - Yozgat Tekstil Ürünleri Sevkiyatı", "LY-3563" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1308,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 277000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 656.0, "Muş", 6812m, 23.0, "Tunceli - Muş Tekstil Ürünleri Sevkiyatı", "LY-2648" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1309,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 404000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 221.0, "Muş", 3114m, 25.0, 2, "Tunceli - Muş Karton Kutu Ambalajları", "LY-2587" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1310,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 397000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 775.0, "Hatay", 11127m, 33.0, "Şanlıurfa - Hatay Tekstil Ürünleri Sevkiyatı", "LY-2305" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1311,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 188000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 232.0, "Amasya", 3472m, 30.0, 2, "Şanlıurfa - Amasya Oto Yedek Parça Nakliyesi", "LY-4418" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1312,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 22000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 640.0, "Denizli", 9226m, 34.0, 2, "Şanlıurfa - Denizli Paletli Gıda Kolileri", "LY-1227" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1313,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 179000m, 109.0, "Kayseri", 1856m, 27.0, "Şanlıurfa - Kayseri Makine Teçhizat Parçaları", "LY-2774" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1314,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 265000m, 792.0, "Bolu", 3933m, 10.0, 2, "Şanlıurfa - Bolu Mobilya ve Ev Eşyası Taşıma", "LY-4588" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1315,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 186000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 309.0, "Mersin", 4147m, 28.0, 2, "Uşak - Mersin Paletli Gıda Kolileri", "LY-8212" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1316,
                columns: new[] { "CargoValue", "Description", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 363000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", "Manisa", 3678m, 17.0, 1, "Uşak - Manisa Plastik Hammadde Sevkiyatı", "LY-7679" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1317,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 440000m, 715.0, "Mardin", 7804m, 24.0, "Uşak - Mardin Oto Yedek Parça Nakliyesi", "LY-2168" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1318,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 269000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 718.0, "Kırşehir", 5651m, 17.0, "Uşak - Kırşehir Paletli Gıda Kolileri", "LY-3700" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1319,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 276000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 195.0, "Malatya", 2570m, 23.0, 1, "Uşak - Malatya Karton Kutu Ambalajları", "LY-9772" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1320,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 199000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 479.0, "Çanakkale", 6064m, 28.0, "Van - Çanakkale Beyaz Eşya Dağıtımı", "LY-3487" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1321,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 264000m, 542.0, "Kastamonu", 5100m, 20.0, "Van - Kastamonu İnşaat Malzemeleri Götürme", "LY-8022" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1322,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 107000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 121.0, "Denizli", 1333m, 15.0, "Van - Denizli Karton Kutu Ambalajları", "LY-2894" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1323,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 401000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 133.0, "Ordu", 2337m, 27.0, 2, "Van - Ordu Tarım Gübresi ve Tohum", "LY-6152" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1324,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 360000m, 202.0, "Aksaray", 3607m, 34.0, 1, "Van - Aksaray Tarım Gübresi ve Tohum", "LY-7347" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1325,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 80000m, 122.0, "Hakkari", 1751m, 24.0, 3, "Yozgat - Hakkari Oto Yedek Parça Nakliyesi", "LY-2310" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1326,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 470000m, 116.0, "Nevşehir", 2501m, 33.0, 2, "Yozgat - Nevşehir Beyaz Eşya Dağıtımı", "LY-6923" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1327,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 288000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 661.0, "Adana", 3432m, 10.0, 1, "Yozgat - Adana Makine Teçhizat Parçaları", "LY-7616" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1328,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 181000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 550.0, "Balıkesir", 7281m, 30.0, 3, "Yozgat - Balıkesir Tarım Gübresi ve Tohum", "LY-5376" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1329,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 205000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 530.0, "Artvin", 3249m, 12.0, 1, "Yozgat - Artvin İnşaat Malzemeleri Götürme", "LY-8008" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1330,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 213000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 866.0, "Van", 9373m, 25.0, "Zonguldak - Van Beyaz Eşya Dağıtımı", "LY-4787" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1331,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 280000m, 785.0, "Trabzon", 11142m, 33.0, 2, "Zonguldak - Trabzon Oto Yedek Parça Nakliyesi", "LY-6330" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1332,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 39000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 336.0, "Bitlis", 2689m, 16.0, 3, "Zonguldak - Bitlis Tekstil Ürünleri Sevkiyatı", "LY-8855" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1333,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 350000m, 631.0, "Bitlis", 6908m, 24.0, 2, "Zonguldak - Bitlis İnşaat Malzemeleri Götürme", "LY-9113" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1334,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 128000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 704.0, "Ankara", 9076m, 30.0, 3, "Zonguldak - Ankara İnşaat Malzemeleri Götürme", "LY-3354" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1335,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 432000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 566.0, "Elazığ", 3422m, 11.0, "Aksaray - Elazığ Mobilya ve Ev Eşyası Taşıma", "LY-7804" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1336,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 289000m, 740.0, "Erzincan", 11149m, 35.0, "Aksaray - Erzincan Tarım Gübresi ve Tohum", "LY-5385" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1337,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 295000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 152.0, "Kırklareli", 1646m, 14.0, 1, "Aksaray - Kırklareli Beyaz Eşya Dağıtımı", "LY-5997" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1338,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 132000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 597.0, "Iğdır", 8751m, 34.0, 2, "Aksaray - Iğdır İnşaat Malzemeleri Götürme", "LY-3917" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1339,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 480000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 829.0, "Erzurum", 4959m, 12.0, "Aksaray - Erzurum Tarım Gübresi ve Tohum", "LY-2336" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1340,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 408000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 678.0, "Kocaeli", 9858m, 33.0, 1, "Bayburt - Kocaeli Beyaz Eşya Dağıtımı", "LY-2801" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1341,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 244000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 485.0, "Sinop", 5400m, 24.0, "Bayburt - Sinop Plastik Hammadde Sevkiyatı", "LY-8466" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1342,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 117000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 540.0, "Gümüşhane", 4505m, 18.0, 3, "Bayburt - Gümüşhane Beyaz Eşya Dağıtımı", "LY-2707" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1343,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 373000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 188.0, "Isparta", 2076m, 16.0, "Bayburt - Isparta İnşaat Malzemeleri Götürme", "LY-1470" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1344,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 214000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 201.0, "Ardahan", 2242m, 19.0, 3, "Bayburt - Ardahan Mobilya ve Ev Eşyası Taşıma", "LY-4552" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1345,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 244000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 805.0, "Kütahya", 9116m, 26.0, 1, "Karaman - Kütahya Tekstil Ürünleri Sevkiyatı", "LY-8336" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1346,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 193000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 354.0, "Manisa", 4799m, 29.0, "Karaman - Manisa Tekstil Ürünleri Sevkiyatı", "LY-9500" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1347,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 100000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 921.0, "Diyarbakır", 9073m, 23.0, "Karaman - Diyarbakır Paletli Gıda Kolileri", "LY-9800" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1348,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 425000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 900.0, "Malatya", 10285m, 26.0, "Karaman - Malatya Beyaz Eşya Dağıtımı", "LY-8339" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1349,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 117000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 884.0, "Erzincan", 4507m, 11.0, 3, "Karaman - Erzincan Paletli Gıda Kolileri", "LY-9824" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1350,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 195000m, 575.0, "Kastamonu", 6905m, 27.0, "Kırıkkale - Kastamonu Makine Teçhizat Parçaları", "LY-6203" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1351,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 254000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 407.0, "Gümüşhane", 6126m, 33.0, 1, "Kırıkkale - Gümüşhane Tekstil Ürünleri Sevkiyatı", "LY-4470" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1352,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 119000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 702.0, "Adana", 10166m, 34.0, 3, "Kırıkkale - Adana Plastik Hammadde Sevkiyatı", "LY-3766" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1353,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 213000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 146.0, "Amasya", 1472m, 13.0, 2, "Kırıkkale - Amasya Makine Teçhizat Parçaları", "LY-9615" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1354,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 339000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 245.0, "Amasya", 2113m, 13.0, 2, "Kırıkkale - Amasya Karton Kutu Ambalajları", "LY-3966" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1355,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 484000m, 781.0, "Kayseri", 10981m, 32.0, 3, "Batman - Kayseri Mobilya ve Ev Eşyası Taşıma", "LY-7657" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1356,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 24000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 309.0, "Zonguldak", 4479m, 32.0, 3, "Batman - Zonguldak Mobilya ve Ev Eşyası Taşıma", "LY-3878" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1357,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 471000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 905.0, "Elazığ", 13279m, 34.0, "Batman - Elazığ Tekstil Ürünleri Sevkiyatı", "LY-3705" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1358,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 88000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 394.0, "Tokat", 3110m, 16.0, 1, "Batman - Tokat İnşaat Malzemeleri Götürme", "LY-2713" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1359,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 367000m, 172.0, "Bitlis", 1899m, 15.0, 1, "Batman - Bitlis Plastik Hammadde Sevkiyatı", "LY-6281" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1360,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 324000m, 136.0, "Malatya", 2021m, 22.0, "Şırnak - Malatya Paletli Gıda Kolileri", "LY-8517" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1361,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 389000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 547.0, "Konya", 7015m, 28.0, 1, "Şırnak - Konya Beyaz Eşya Dağıtımı", "LY-5540" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1362,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 273000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 676.0, "Afyonkarahisar", 4288m, 13.0, 3, "Şırnak - Afyonkarahisar Beyaz Eşya Dağıtımı", "LY-8009" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1363,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 148000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 569.0, "Eskişehir", 7476m, 30.0, 1, "Şırnak - Eskişehir Mobilya ve Ev Eşyası Taşıma", "LY-2103" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1364,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 60000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 189.0, "Tunceli", 2450m, 25.0, "Şırnak - Tunceli Oto Yedek Parça Nakliyesi", "LY-7154" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1365,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 336000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 427.0, "Uşak", 5960m, 30.0, "Bartın - Uşak Plastik Hammadde Sevkiyatı", "LY-6846" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1366,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 473000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 111.0, "Kahramanmaraş", 1639m, 15.0, 2, "Bartın - Kahramanmaraş Makine Teçhizat Parçaları", "LY-9555" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1367,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 129000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 305.0, "Muğla", 2703m, 2, "Bartın - Muğla Paletli Gıda Kolileri", "LY-5146" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1368,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 447000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 907.0, "Uşak", 11831m, 30.0, "Bartın - Uşak Paletli Gıda Kolileri", "LY-2901" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1369,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 86000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 658.0, "Kastamonu", 3481m, 11.0, 3, "Bartın - Kastamonu Plastik Hammadde Sevkiyatı", "LY-8453" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1370,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 338000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 788.0, "Afyonkarahisar", 7772m, 22.0, "Ardahan - Afyonkarahisar Makine Teçhizat Parçaları", "LY-4406" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1371,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 310000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 572.0, "Isparta", 3098m, 10.0, 2, "Ardahan - Isparta Tekstil Ürünleri Sevkiyatı", "LY-5548" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1372,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 65000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 669.0, "Aydın", 6185m, 21.0, "Ardahan - Aydın Mobilya ve Ev Eşyası Taşıma", "LY-5205" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1373,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 341000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 486.0, "Denizli", 3951m, 16.0, 2, "Ardahan - Denizli Beyaz Eşya Dağıtımı", "LY-3346" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1374,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 442000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 197.0, "Iğdır", 3306m, 30.0, "Ardahan - Iğdır Paletli Gıda Kolileri", "LY-5174" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1375,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 498000m, 819.0, "Isparta", 6567m, 17.0, 3, "Iğdır - Isparta Mobilya ve Ev Eşyası Taşıma", "LY-5308" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1376,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 38000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 894.0, "Rize", 10551m, 28.0, 1, "Iğdır - Rize Plastik Hammadde Sevkiyatı", "LY-7649" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1377,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 237000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 715.0, "Bursa", 10175m, 33.0, "Iğdır - Bursa Paletli Gıda Kolileri", "LY-3899" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1378,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 154000m, 293.0, 4053m, 29.0, "Iğdır - Ardahan Plastik Hammadde Sevkiyatı", "LY-2531" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1379,
                columns: new[] { "CargoImageUrl", "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 394000m, 307.0, "Adana", 3841m, 3, "Iğdır - Adana Paletli Gıda Kolileri", "LY-4776" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1380,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 59000m, 859.0, "Iğdır", 3995m, 10.0, 1, "Yalova - Iğdır Paletli Gıda Kolileri", "LY-5542" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1381,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 107000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 896.0, "Trabzon", 7058m, 18.0, "Yalova - Trabzon Beyaz Eşya Dağıtımı", "LY-9883" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1382,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 66000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 415.0, "Mersin", 4384m, 23.0, 1, "Yalova - Mersin Makine Teçhizat Parçaları", "LY-6645" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1383,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 379000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 446.0, 6945m, 34.0, 1, "Yalova - Gümüşhane Paletli Gıda Kolileri", "LY-5217" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1384,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 302000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 810.0, "Hatay", 12142m, 35.0, 1, "Yalova - Hatay Makine Teçhizat Parçaları", "LY-1258" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1385,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 25000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 799.0, "Erzurum", 8835m, 26.0, "Karabük - Erzurum Karton Kutu Ambalajları", "LY-9972" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1386,
                columns: new[] { "CargoValue", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 56000m, 807.0, "Van", 8949m, 26.0, "Karabük - Van Plastik Hammadde Sevkiyatı", "LY-9107" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1387,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 116000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 946.0, "Uşak", 12725m, 32.0, 2, "Karabük - Uşak Paletli Gıda Kolileri", "LY-7382" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1388,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 322000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 789.0, "Edirne", 6503m, 18.0, 1, "Karabük - Edirne Oto Yedek Parça Nakliyesi", "LY-7946" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1389,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 109000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 390.0, "Bayburt", 4977m, 28.0, 3, "Karabük - Bayburt Tekstil Ürünleri Sevkiyatı", "LY-9874" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1390,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 194000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 357.0, "Van", 5121m, 31.0, 3, "Kilis - Van Paletli Gıda Kolileri", "LY-1951" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1391,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 269000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 191.0, "Gümüşhane", 2373m, 21.0, 3, "Kilis - Gümüşhane Makine Teçhizat Parçaları", "LY-6805" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1392,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 207000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 241.0, "Sinop", 3213m, 26.0, 2, "Kilis - Sinop Oto Yedek Parça Nakliyesi", "LY-8477" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1393,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 414000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 604.0, "Hatay", 4296m, 14.0, 1, "Kilis - Hatay Mobilya ve Ev Eşyası Taşıma", "LY-3987" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1394,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 125000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 870.0, "Eskişehir", 12109m, 33.0, "Kilis - Eskişehir Paletli Gıda Kolileri", "LY-4126" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1395,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 375000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 379.0, "Hatay", 4210m, 22.0, 2, "Osmaniye - Hatay Paletli Gıda Kolileri", "LY-4258" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1396,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 308000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 448.0, "Adıyaman", 6901m, 34.0, 2, "Osmaniye - Adıyaman Tekstil Ürünleri Sevkiyatı", "LY-4817" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1397,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 24000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 553.0, "Kırıkkale", 8266m, 35.0, 1, "Osmaniye - Kırıkkale Beyaz Eşya Dağıtımı", "LY-3738" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1398,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 266000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 511.0, "Erzincan", 4445m, 18.0, 1, "Osmaniye - Erzincan Tekstil Ürünleri Sevkiyatı", "LY-4904" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1399,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { 488000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 644.0, "Artvin", 3564m, 10.0, 3, "Osmaniye - Artvin Karton Kutu Ambalajları", "LY-5264" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1400,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 415000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 710.0, "Kırklareli", 6311m, 19.0, "Düzce - Kırklareli Mobilya ve Ev Eşyası Taşıma", "LY-4002" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1401,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 461000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 415.0, "Siirt", 3783m, 17.0, "Düzce - Siirt Oto Yedek Parça Nakliyesi", "LY-6293" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1402,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 452000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 530.0, "Kırklareli", 4132m, 15.0, 1, "Düzce - Kırklareli Paletli Gıda Kolileri", "LY-5246" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1403,
                columns: new[] { "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "Title", "VerificationCode" },
                values: new object[] { 116000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 862.0, "Kırklareli", 9236m, 25.0, "Düzce - Kırklareli Beyaz Eşya Dağıtımı", "LY-1848" });

            migrationBuilder.UpdateData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1404,
                columns: new[] { "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "Title", "VerificationCode" },
                values: new object[] { "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 470000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 493.0, "Hatay", 7083m, 31.0, 3, "Düzce - Hatay Tarım Gübresi ve Tohum", "LY-8891" });
        }
    }
}
