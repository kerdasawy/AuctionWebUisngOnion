using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace AuctionWeb.Service.Features.ItemFeature.Commands
{
    public class CreateItemCommand : IRequest<int>
    {
        public string ItemName { get; set; }


        public decimal Price { get; set; }
        public class CreateBidderCommandHandler : IRequestHandler<CreateItemCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateBidderCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
            {
                var item = new Item();
                item.ItemName = request.ItemName;
                item.Price = request.Price;

                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return item.Id;
                

            }
        }
    }
}
