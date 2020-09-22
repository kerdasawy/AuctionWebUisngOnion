using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace AuctionWeb.Service.Features.AuctionFeature.Commands
{
    public class AddBidToAuctionCommand : IRequest<int>
    {
        public const int AuctionTimeOut = 60;
        public int BidderID { get; set; }
        public int AuctionID { get; set; }
        public decimal Bid { get; set; }
        public class AddBidToAuctionCommandHandler : IRequestHandler<AddBidToAuctionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddBidToAuctionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddBidToAuctionCommand request, CancellationToken cancellationToken)
            {
                //Check in bidder in auction
                //Check if the bid is bigger than last on
                var lastBid = _context.AuctionBiddings.Where(a => a.Auction_ID == request.AuctionID).OrderByDescending(o => o.BidValue).FirstOrDefault();
                var auctionObj = _context.Auctions.Find(request.AuctionID);
                var item =( auctionObj !=null)? auctionObj.Item?? _context.Items.Find(auctionObj.Item_ID):null;
                await AddBidToAuctionCommand.checkAuctionTimes(_context);
                //Check if the bid is bigger than last on
                if (!item.BidderID.HasValue&&((lastBid!=null&& lastBid.BidValue<request.Bid  )||
                    //Frist Bid
                    (auctionObj != null &&  item.Price < request.Bid)))
                {
                    //Add bid
                    var bidding = new AuctionBidding() {  Auction_ID = request.AuctionID , Bidder_ID = request.BidderID , BidValue = request.Bid, BiddingTime = DateTime.Now};

                    _context.AuctionBiddings.Add(bidding);
                    await _context.SaveChangesAsync();
                    return bidding.Id;
                }
                
                else
                {
                    //refused bid
                    return default;
                }
               
                return default;
               
            }

        
        }
        public static async Task checkAuctionTimes(IApplicationDbContext _context)
        {
            DateTime now = DateTime.Now;
            //If the last bit passes 1 min the auction winner is last bid
            var seacnd = _context.Auctions.Where(a => !a.Item.BidderID.HasValue && a.Biddings.Count > 0).Select(a =>
            EF.Functions.DateDiffSecond( a.Biddings.OrderByDescending(b => b.BiddingTime).First().BiddingTime,now)
            ).ToArray();
          
            var res = await _context.Auctions.Where(a => !a.Item.BidderID.HasValue
            && a.Biddings.Count > 0
            && EF.Functions.DateDiffSecond (a.Biddings.OrderByDescending(b => b.BiddingTime).First().BiddingTime,now) >= AuctionTimeOut
            ).ToArrayAsync();
            foreach (var item in res)
            {
                item.Item.BidderID = item.Biddings.OrderByDescending(b => b.BiddingTime).First().Bidder_ID;
            }
            await _context.SaveChangesAsync();
        }
    }
}
