using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.ItemFeature.Commands
{
    public class UpdateItemCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ItemName { get; set; }


        public decimal Price { get; set; }
        public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
            {
                var item = _context.Items.Where(a => a.Id == request.Id).FirstOrDefault();

                if (item == null)
                {
                    return default;
                }
                else
                {
                    item.ItemName = request.ItemName;
                    item.Price = request.Price;
                    _context.Items.Update(item);
                    await _context.SaveChangesAsync();
                    return item.Id;
                }
               
            }
        }
    }
}
