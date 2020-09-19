using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionWeb.Persistence.Migrations
{
    public partial class start9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BidValue",
                table: "AuctionBiddings",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "Bidders",
                columns: new[] { "Id", "Address", "BidderName", "City", "ContactName", "ContactTitle", "Country", "Fax", "Phone", "PostalCode", "Region" },
                values: new object[,]
                {
                    { 1, null, "Abdo", null, "MR Abdo", null, null, null, null, null, null },
                    { 2, null, "Abdo2", null, "MR Abdo2", null, null, null, null, null, null },
                    { 3, null, "Abdo3", null, "MR Abdo3", null, null, null, null, null, null },
                    { 4, null, "Abdo4", null, "MR Abdo4", null, null, null, null, null, null },
                    { 5, null, "Abdo5", null, "MR Abdo5", null, null, null, null, null, null },
                    { 6, null, "Abdo6", null, "MR Abdo6", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ItemName", "Price" },
                values: new object[,]
                {
                    { 1, "Histrorical Watch", 10000m },
                    { 2, "Histrorical Glass", 20000m },
                    { 3, "Histrorical Sword", 50000m },
                    { 4, "Histrorical Hat", 5000m },
                    { 5, "Histrorical Paint", 100000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bidders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bidders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bidders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bidders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bidders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bidders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<float>(
                name: "BidValue",
                table: "AuctionBiddings",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
