using MediatR;
using Microsoft.EntityFrameworkCore;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.BidderFeatures.Queries
{
    public class GetAllBidderQuery : IRequest<IEnumerable<Bidder>>
    {

        public class GetAllBidderQueryHandler : IRequestHandler<GetAllBidderQuery, IEnumerable<Bidder>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBidderQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Bidder>> Handle(GetAllBidderQuery request, CancellationToken cancellationToken)
            {
                var BidderList = await _context.Bidders.ToListAsync();
                if (BidderList == null)
                {
                    return null;
                }
                return BidderList.AsReadOnly();
               
            }
        }
    }
}
