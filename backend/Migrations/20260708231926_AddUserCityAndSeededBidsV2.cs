using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCityAndSeededBidsV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "AdId", "Amount", "CarrierId", "Status" },
                values: new object[,]
                {
                    { 101, 1, 3500m, 2, "Pending" },
                    { 102, 2, 6500m, 3, "Pending" },
                    { 103, 3, 8300m, 4, "Pending" },
                    { 104, 101, 3400m, 2, "Pending" },
                    { 105, 101, 3300m, 3, "Pending" },
                    { 106, 104, 4350m, 3, "Pending" },
                    { 107, 102, 6000m, 4, "Pending" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "City",
                value: "İstanbul");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: "İstanbul");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "City",
                value: "Ankara");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "City",
                value: "İzmir");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");
        }
    }
}
