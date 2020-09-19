using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionWeb.Service.Features.BidderFeatures.Commands
{
    public class UpdateBidderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string BidderName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public class UpdateBidderCommandHandler : IRequestHandler<UpdateBidderCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateBidderCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateBidderCommand request, CancellationToken cancellationToken)
            {
                var bidder = _context.Bidders.Where(a => a.Id == request.Id).FirstOrDefault();

                if (bidder == null)
                {
                    return default;
                }
                else
                {
                    PropertyCopier<UpdateBidderCommand, Bidder>.Copy(request, bidder);
                    _context.Bidders.Update(bidder);
                    await _context.SaveChangesAsync();
                    return bidder.Id;
                }
               
            }
        }
    }
}
