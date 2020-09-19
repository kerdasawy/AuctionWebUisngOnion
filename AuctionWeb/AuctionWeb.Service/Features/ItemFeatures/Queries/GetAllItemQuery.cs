using MediatR;
using Microsoft.EntityFrameworkCore;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.ItemFeature.Queries
{
    public class GetAllItemQuery : IRequest<IEnumerable<Item>>
    {

        public class GetAllItemQueryHandler : IRequestHandler<GetAllItemQuery, IEnumerable<Item>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllItemQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Item>> Handle(GetAllItemQuery request, CancellationToken cancellationToken)
            {
                var itemList = await _context.Items.ToListAsync();
                if (itemList == null)
                {
                    return null;
                }
                return itemList.AsReadOnly();
                
            }
        }
    }
}
