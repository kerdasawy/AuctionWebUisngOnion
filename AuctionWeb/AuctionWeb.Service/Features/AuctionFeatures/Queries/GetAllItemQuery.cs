using MediatR;
using Microsoft.EntityFrameworkCore;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.AuctionFeature.Queries
{
    public class GetAllAuctionQuery : IRequest<IEnumerable<Auction>>
    {

        public class GetAllAuctionQueryHandler : IRequestHandler<GetAllAuctionQuery, IEnumerable<Auction>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllAuctionQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Auction>> Handle(GetAllAuctionQuery request, CancellationToken cancellationToken)
            {
                var AuctionList = await _context.Auctions.ToListAsync();
                if (AuctionList == null)
                {
                    return null;
                }
                return AuctionList.AsReadOnly();
               
            }
        }
    }
}
