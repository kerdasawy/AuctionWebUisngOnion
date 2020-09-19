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
    public class AddBidderToAuctionCommand : IRequest<int>
    {
        public int BidderID { get; set; }
        public int AuctionID { get; set; }
        public class AddBidderToAuctionCommandHandler : IRequestHandler<AddBidderToAuctionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public AddBidderToAuctionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(AddBidderToAuctionCommand request, CancellationToken cancellationToken)
            {
                var bidderAuction = _context.BidderAuctions.Where(ab => ab.Auctions.Id == request.AuctionID &&
                ab.Bidders.Id == request.BidderID
                ).FirstOrDefault();
                if (bidderAuction==null)
                {
                    var auction = _context.Auctions.Where(a => a.Id == request.AuctionID).FirstOrDefault();
                    var bidder = _context.Bidders.Where(b => b.Id == request.BidderID).FirstOrDefault();
                    if (auction==null || bidder==null)
                    {
                        //Auction or Bidder not found 
                        return default;
                    }
                    else
                    {
                        var ab = new BidderAuction() { Auctions = auction , Bidders = bidder };
                        _context.BidderAuctions.Add(ab);
                        await _context.SaveChangesAsync();
                        return ab.Id;
                    }
                }
                else
                {
                    //Added before
                    return bidderAuction.Id;
                }
               
            }
        }
    }
}
