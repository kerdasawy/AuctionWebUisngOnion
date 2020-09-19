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
                //Check if the bid is bigger than last on
                if (lastBid.BidValue<request.Bid)
                {
                    //Add bid
                    var bidding = new AuctionBidding() {  Auction_ID = request.AuctionID , Bidder_ID = request.BidderID , BidValue = request.Bid};

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
    }
}
