using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace AuctionWeb.Service.Features.AuctionFeature.Commands
{
    public class UpdateAuctionCommand : IRequest<int>
    {
        public int ID { get; set; }
        public int Item_ID { get; set; }
        public DateTime StartDate { get; set; }
        public class UpdateAuctionCommandHandler : IRequestHandler<UpdateAuctionCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateAuctionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateAuctionCommand request, CancellationToken cancellationToken)
            {
                var auction = _context.Auctions.Where(a => a.Id == request.ID).FirstOrDefault();

                if (auction == null)
                {
                    return default;
                }
                else
                {
                    auction.Item_ID = request.Item_ID;
                    auction.StartDate = request.StartDate;
                    _context.Auctions.Update(auction);
                    await _context.SaveChangesAsync();
                    return auction.Id;
                }
               
            }
        }
    }
}
