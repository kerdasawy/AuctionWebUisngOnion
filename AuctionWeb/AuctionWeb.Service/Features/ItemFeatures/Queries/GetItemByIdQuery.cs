using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.ItemFeature.Queries
{
    public class GetItemByIdQuery : IRequest<Item>
    {
        public int Id { get; set; }
        public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, Item>
        {
            private readonly IApplicationDbContext _context;
            public GetItemByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Item> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
            {
                var item = _context.Items.Where(a => a.Id == request.Id).FirstOrDefault();
                if (item == null) return null;
                return item;
               
            }
        }
    }
}
