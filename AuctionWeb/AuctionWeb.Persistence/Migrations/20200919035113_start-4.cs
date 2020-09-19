using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionWeb.Persistence.Migrations
{
    public partial class start4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BidderId",
                table: "Auctions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_BidderId",
                table: "Auctions",
                column: "BidderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Bidders_BidderId",
                table: "Auctions",
                column: "BidderId",
                principalTable: "Bidders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Bidders_BidderId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_BidderId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "BidderId",
                table: "Auctions");
        }
    }
}
