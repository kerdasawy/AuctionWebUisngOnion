using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.AuctionFeature.Queries
{
    public class GetAuctionByIdQuery : IRequest<Auction>
    {
        public int Id { get; set; }
        public class GetAuctionByIdQueryHandler : IRequestHandler<GetAuctionByIdQuery, Auction>
        {
            private readonly IApplicationDbContext _context;
            public GetAuctionByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Auction> Handle(GetAuctionByIdQuery request, CancellationToken cancellationToken)
            {
                var auction = _context.Auctions.Where(a => a.Id == request.Id).FirstOrDefault();
                if (auction == null) return null;
                return auction;
               
            }
        }
    }
}
