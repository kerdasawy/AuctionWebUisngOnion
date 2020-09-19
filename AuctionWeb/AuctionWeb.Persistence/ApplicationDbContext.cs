using Microsoft.EntityFrameworkCore;
using AuctionWeb.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

       public DbSet<Bidder> Bidders { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBidding> AuctionBiddings { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<BidderAuction> BidderAuctions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>().HasOne<Item>(a=>a.Item).WithMany(i=>i.Auctions);
            modelBuilder.Entity<BidderAuction>().HasOne<Auction>(b => b.Auctions).WithMany(a=>a.Bidders);
            modelBuilder.Entity<BidderAuction>().HasOne<Bidder>(a => a.Bidders).WithMany(b=>b.Auctions);   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer(@"Server=ABDO-PC\IT1_SQL_2012;Database=AuctionWen.DB;Trusted_Connection=True;");
            }

        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
