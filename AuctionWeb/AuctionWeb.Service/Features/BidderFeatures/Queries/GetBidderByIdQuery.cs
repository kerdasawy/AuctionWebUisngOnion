using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.BidderFeatures.Queries
{
    public class GetBidderByIdQuery : IRequest<Bidder>
    {
        public int Id { get; set; }
        public class GetBidderByIdQueryHandler : IRequestHandler<GetBidderByIdQuery, Bidder>
        {
            private readonly IApplicationDbContext _context;
            public GetBidderByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Bidder> Handle(GetBidderByIdQuery request, CancellationToken cancellationToken)
            {
                var Bidder =   _context.Bidders.Where(a => a.Id == request.Id).FirstOrDefault();
                if (Bidder == null) return null;
                return Bidder;
                 
            }
        }
    }
}
