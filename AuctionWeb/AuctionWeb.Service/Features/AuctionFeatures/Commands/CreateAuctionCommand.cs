using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace AuctionWeb.Service.Features.AuctionFeature.Commands
{
    public class CreateAuctionCommand : IRequest<int>
    {
        public int Item_ID { get; set; }
        public DateTime StartDate { get; set; }
        public class CreateBidderCommandHandler : IRequestHandler<CreateAuctionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateBidderCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateAuctionCommand request, CancellationToken cancellationToken)
            {
                var auction = new Auction();
                auction.Item_ID = request.Item_ID;
                auction.StartDate    = request.StartDate;

                _context.Auctions.Add(auction);
                await _context.SaveChangesAsync();
                return auction.Id;
                

            }
        }
    }
}
