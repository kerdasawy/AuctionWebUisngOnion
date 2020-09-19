using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace AuctionWeb.Service.Features.BidderFeatures.Commands
{
    public class CreateBiderCommand : IRequest<int>
    {
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
        public class CreateBidderCommandHandler : IRequestHandler<CreateBiderCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateBidderCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateBiderCommand request, CancellationToken cancellationToken)
            {
                var bidder = new Bidder();

                PropertyCopier<CreateBiderCommand, Bidder>.Copy(request, bidder);
                _context.Bidders.Add(bidder);
                await _context.SaveChangesAsync();
                return bidder.Id;
                

            }
        }
    }
}
