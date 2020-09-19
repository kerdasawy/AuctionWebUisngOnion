using MediatR;
using Microsoft.EntityFrameworkCore;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.AuctionFeature.Commands
{
    public class DeleteAuctionByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteAuctionByIdCommandHandler : IRequestHandler<DeleteAuctionByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteAuctionByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteAuctionByIdCommand request, CancellationToken cancellationToken)
            {
                var auction = await _context.Auctions.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (auction == null) return default;
                _context.Auctions.Remove(auction);
                await _context.SaveChangesAsync();
                return auction.Id;
               
            }
        }
    }
}
