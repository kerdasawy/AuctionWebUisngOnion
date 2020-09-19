using MediatR;
using Microsoft.EntityFrameworkCore;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.BidderFeatures.Commands
{
    public class DeleteBidderByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteBidderByIdCommandHandler : IRequestHandler<DeleteBidderByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteBidderByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBidderByIdCommand request, CancellationToken cancellationToken)
            {
                var item = await _context.Bidders.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (item == null) return default;
                _context.Bidders.Remove(item);
                await _context.SaveChangesAsync();
                return item.Id;
               
            }
        }
    }
}
