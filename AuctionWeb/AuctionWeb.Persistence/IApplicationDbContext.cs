using Microsoft.EntityFrameworkCore;
using AuctionWeb.Domain.Entities;
using System.Threading.Tasks;

namespace AuctionWeb.Persistence
{
    public interface IApplicationDbContext
    {
        
        DbSet<Bidder> Bidders { get; set; }
        DbSet<Auction> Auctions { get; set; }
        DbSet<AuctionBidding > AuctionBiddings { get; set; }
        DbSet<Item > Items { get; set; }
         DbSet<BidderAuction> BidderAuctions { get; set; }
        Task<int> SaveChangesAsync();
    }
}
