using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionWeb.Persistence.Migrations
{
    public partial class start5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Bidders_BidderId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Bidders_Auctions_AuctionId",
                table: "Bidders");

            migrationBuilder.DropIndex(
                name: "IX_Bidders_AuctionId",
                table: "Bidders");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_BidderId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "AuctionId",
                table: "Bidders");

            migrationBuilder.DropColumn(
                name: "BidderId",
                table: "Auctions");

            migrationBuilder.CreateTable(
                name: "BidderAuctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiddersId = table.Column<int>(nullable: true),
                    AuctionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidderAuctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidderAuctions_Auctions_AuctionsId",
                        column: x => x.AuctionsId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BidderAuctions_Bidders_BiddersId",
                        column: x => x.BiddersId,
                        principalTable: "Bidders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BidderAuctions_AuctionsId",
                table: "BidderAuctions",
                column: "AuctionsId");

            migrationBuilder.CreateIndex(
                name: "IX_BidderAuctions_BiddersId",
                table: "BidderAuctions",
                column: "BiddersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidderAuctions");

            migrationBuilder.AddColumn<int>(
                name: "AuctionId",
                table: "Bidders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BidderId",
                table: "Auctions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bidders_AuctionId",
                table: "Bidders",
                column: "AuctionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bidders_Auctions_AuctionId",
                table: "Bidders",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
