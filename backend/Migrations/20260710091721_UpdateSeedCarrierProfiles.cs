using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedCarrierProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarrierProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseType",
                value: "A2 Sınıfı (Moto Kurye)");

            migrationBuilder.UpdateData(
                table: "CarrierProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsuranceNo", "LicenseType" },
                values: new object[] { "Vergi No: 198230281", "Şahıs Şirketi (Doğrulandı)" });

            migrationBuilder.UpdateData(
                table: "CarrierProfiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "LicenseType",
                value: "CE (Ağır Vasıta - Sigortalı)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarrierProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseType",
                value: "B Sınıfı");

            migrationBuilder.UpdateData(
                table: "CarrierProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsuranceNo", "LicenseType" },
                values: new object[] { "", "C Sınıfı" });

            migrationBuilder.UpdateData(
                table: "CarrierProfiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "LicenseType",
                value: "CE (Ağır Vasıta)");
        }
    }
}
