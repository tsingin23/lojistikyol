using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLevel = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceKm = table.Column<double>(type: "float", nullable: false),
                    FuelConsumptionRate = table.Column<double>(type: "float", nullable: false),
                    CargoValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FloorPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequiredLevel = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ads_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarrierProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LicenseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    InsuranceNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrierProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdId = table.Column<int>(type: "int", nullable: false),
                    CarrierId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Users_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidId = table.Column<int>(type: "int", nullable: false),
                    AuthCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountBlockedSender = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountBlockedCarrier = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Bids_BidId",
                        column: x => x.BidId,
                        principalTable: "Bids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "Name", "UserLevel", "UserType" },
                values: new object[,]
                {
                    { 1, 150000m, "Ahmet (Gönderici)", 1, "Sender" },
                    { 2, 20000m, "Mehmet (Lvl 1 Taşıyıcı)", 1, "Carrier" },
                    { 3, 25000m, "Ali (Lvl 2 Taşıyıcı)", 2, "Carrier" },
                    { 4, 5000m, "Veli (Lvl 3 Taşıyıcı)", 3, "Carrier" }
                });

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "Id", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "SenderId", "StartLocation", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 80000m, "2+1 ev eşyası taşınacaktır. Dikkatli ve özenli taşıma gereklidir.", 480.0, "İstanbul", 3360m, 12.0, 1, 1, "İzmir", "Active", "İzmir - İstanbul Ev Eşyası Taşıma" },
                    { 2, 200000m, "15 ton paletli demir boru sevkiyatı. Dorseli tır gereklidir.", 350.0, "Ankara", 6240m, 32.0, 2, 1, "Kocaeli", "Active", "Kocaeli - Ankara Paletli Demir Boru" },
                    { 3, 500000m, "Yüksek riskli kimyasal madde taşıması. ADR belgeli araç ve özel sigorta zorunludur.", 420.0, "Batman", 8115m, 35.0, 3, 1, "İskenderun", "Active", "İskenderun - Batman Kimyasal Hammadde" }
                });

            migrationBuilder.InsertData(
                table: "CarrierProfiles",
                columns: new[] { "Id", "InsuranceNo", "LicenseType", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "", "B Sınıfı", 4.2000000000000002, 2 },
                    { 2, "", "C Sınıfı", 4.7000000000000002, 3 },
                    { 3, "POL-9876543-XYZ", "CE (Ağır Vasıta)", 4.9000000000000004, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_SenderId",
                table: "Ads",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AdId",
                table: "Bids",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_CarrierId",
                table: "Bids",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrierProfiles_UserId",
                table: "CarrierProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BidId",
                table: "Transactions",
                column: "BidId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrierProfiles");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
