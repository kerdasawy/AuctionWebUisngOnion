using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionWeb.Persistence.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bidders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidderName = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactTitle = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    BidderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Bidders_BidderID",
                        column: x => x.BidderID,
                        principalTable: "Bidders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_ID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Items_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionBiddings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auction_ID = table.Column<int>(nullable: false),
                    Bidder_ID = table.Column<int>(nullable: false),
                    BiddingTime = table.Column<DateTime>(nullable: false),
                    BidValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionBiddings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionBiddings_Auctions_Auction_ID",
                        column: x => x.Auction_ID,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionBiddings_Bidders_Bidder_ID",
                        column: x => x.Bidder_ID,
                        principalTable: "Bidders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidderAuctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidderID = table.Column<int>(nullable: false),
                    AuctionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidderAuctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidderAuctions_Auctions_AuctionID",
                        column: x => x.AuctionID,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BidderAuctions_Bidders_BidderID",
                        column: x => x.BidderID,
                        principalTable: "Bidders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "BidderID", "ItemName", "Price" },
                values: new object[,]
                {
                    { 1, null, "Histrorical Watch", 10000m },
                    { 2, null, "Histrorical Glass", 20000m },
                    { 3, null, "Histrorical Sword", 50000m },
                    { 4, null, "Histrorical Hat", 5000m },
                    { 5, null, "Histrorical Paint", 100000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionBiddings_Auction_ID",
                table: "AuctionBiddings",
                column: "Auction_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionBiddings_Bidder_ID",
                table: "AuctionBiddings",
                column: "Bidder_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_Item_ID",
                table: "Auctions",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BidderAuctions_AuctionID",
                table: "BidderAuctions",
                column: "AuctionID");

            migrationBuilder.CreateIndex(
                name: "IX_BidderAuctions_BidderID",
                table: "BidderAuctions",
                column: "BidderID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BidderID",
                table: "Items",
                column: "BidderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionBiddings");

            migrationBuilder.DropTable(
                name: "BidderAuctions");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Bidders");
        }
    }
}
