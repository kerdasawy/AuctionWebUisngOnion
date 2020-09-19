using MediatR;
using Microsoft.EntityFrameworkCore;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.ItemFeature.Commands
{
    public class DeleteItemByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteItemByIdCommandHandler : IRequestHandler<DeleteItemByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteItemByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteItemByIdCommand request, CancellationToken cancellationToken)
            {
                var item = await _context.Items.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (item == null) return default;
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return item.Id;
               
            }
        }
    }
}
