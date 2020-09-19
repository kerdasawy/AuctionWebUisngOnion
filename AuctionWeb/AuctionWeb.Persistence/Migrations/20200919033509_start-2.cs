using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionWeb.Persistence.Migrations
{
    public partial class start2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuctionId",
                table: "Bidders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bidders_AuctionId",
                table: "Bidders",
                column: "AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bidders_Auctions_AuctionId",
                table: "Bidders",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bidders_Auctions_AuctionId",
                table: "Bidders");

            migrationBuilder.DropIndex(
                name: "IX_Bidders_AuctionId",
                table: "Bidders");

            migrationBuilder.DropColumn(
                name: "AuctionId",
                table: "Bidders");
        }
    }
}
