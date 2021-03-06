﻿using Microsoft.EntityFrameworkCore;
using AuctionWeb.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.Extensions.Options;

namespace AuctionWeb.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        // This constructor is used of runit testing
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

       public DbSet<Bidder> Bidders { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBidding> AuctionBiddings { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<BidderAuction> BidderAuctions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>().HasOne<Item>(a=>a.Item).WithMany(i=>i.Auctions).HasForeignKey(a=>a.Item_ID);
            modelBuilder.Entity<BidderAuction>().HasOne<Auction>(b => b.Auctions).WithMany(a=>a.Bidders).HasForeignKey(ba=>ba.AuctionID);
            modelBuilder.Entity<BidderAuction>().HasOne<Bidder>(a => a.Bidders).WithMany(b=>b.Auctions).HasForeignKey(ba=>ba.BidderID);
            modelBuilder.Entity<Item>().HasOne<Bidder>(i => i.Bidder).WithMany(b => b.Items).HasForeignKey(i=>i.BidderID) ;
            modelBuilder.Entity<Item>().HasMany<Auction>(i => i.Auctions).WithOne(a => a.Item).HasForeignKey(a=>a.Item_ID);
            modelBuilder.Entity<Auction>().HasOne<Item>(a => a.Item).WithMany(i => i.Auctions).HasForeignKey(a=>a.Item_ID);
            
            modelBuilder.Entity<AuctionBidding>().HasOne<Auction>(ab => ab.Auction).WithMany(a => a.Biddings).HasForeignKey(ab=>ab.Auction_ID);
            modelBuilder.Entity<AuctionBidding>().HasOne<Bidder>(ab => ab.Bidder).WithMany(a => a.Biddings).HasForeignKey(ab => ab.Bidder_ID);
            

            //seeding Data...

            #region Seeding Data

            #region Items in store
            modelBuilder.Entity<Item>().HasData(
                           new Item() { Id = 1,ItemName = "Histrorical Watch", Price = 10000 },
                           new Item() { Id = 2, ItemName = "Histrorical Glass", Price = 20000 },
                           new Item() { Id = 3, ItemName = "Histrorical Sword", Price = 50000 },
                           new Item() { Id = 4, ItemName = "Histrorical Hat", Price = 5000 },
                           new Item() { Id = 5, ItemName = "Histrorical Paint", Price = 100000 }
                           );
                #endregion

                #region Auctions
              


                #endregion

                #region Bidder
                modelBuilder.Entity<Bidder>().HasData(
                         new Bidder() { Id = 1, BidderName ="Abdo",ContactName="MR Abdo" },
                         new Bidder() { Id =2, BidderName = "Abdo2", ContactName = "MR Abdo2" },
                         new Bidder() { Id = 3, BidderName = "Abdo3", ContactName = "MR Abdo3" },
                         new Bidder() { Id =4, BidderName = "Abdo4", ContactName = "MR Abdo4" },
                         new Bidder() { Id = 5, BidderName = "Abdo5", ContactName = "MR Abdo5" },
                         new Bidder() { Id = 6, BidderName = "Abdo6", ContactName = "MR Abdo6" }
                         );
                #endregion
                #endregion
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer(@"Server=ABDO-PC\IT1_SQL_2012;Database=AuctionWen.DB;Trusted_Connection=True;")
                
                ;
                


            }
            //services.AddDbContext(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
