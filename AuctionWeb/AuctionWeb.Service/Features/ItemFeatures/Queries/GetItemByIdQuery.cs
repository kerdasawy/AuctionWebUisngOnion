using MediatR;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using AuctionWeb.Persistence.ViewModel;

namespace AuctionWeb.Service.Features.ItemFeature.Queries
{
    public class GetItemByIdQuery : IRequest<AuctionItemViewModel>
    {
        public int Id { get; set; }
        public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, AuctionItemViewModel>
        {
            private readonly IApplicationDbContext _context;
            public GetItemByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<AuctionItemViewModel> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    await AuctionFeature.Commands.AddBidToAuctionCommand.checkAuctionTimes(_context);
                    var itemList = await _context.Items
                        .Include(i=>i.Bidder)
                        .Include(i=>i.Auctions)
                        .ThenInclude(a=>a.Biddings)
                        .ThenInclude(b=>b.Bidder)
                        .Where(i=>i.Id==request.Id).ToListAsync();
                    //adding items to auction by defualt
                    var notInAuctionItems = itemList.Where(i => i.Auctions.Count() == 0).ToArray();
                    foreach (var item in notInAuctionItems)
                    {
                        var auctionForItem = new Auction() { Item_ID = item.Id, StartDate = DateTime.Now.AddMinutes(10) };
                        await _context.Auctions.AddAsync(auctionForItem);
                    }

                    if (notInAuctionItems.Length > 0)
                    {
                        await _context.SaveChangesAsync();
                    }

                    if (itemList == null)
                    {
                        return null;
                    }
                    var res = itemList.Select(i => new AuctionItemViewModel()
                    {
                        name = i.ItemName,
                        Item_ID = i.Id,
                        price = i.Price,
                        bidder_ID = i.Bidder?.Id,
                        LastBidder = (i.Auctions.Last().Biddings.Count() > 0) ? i.Auctions.Last().Biddings.OrderByDescending(bb => bb.BiddingTime).FirstOrDefault().Bidder.BidderName : "",
                        LastBidderID = (i.Auctions.Last().Biddings.Count() > 0) ? i.Auctions.Last().Biddings.OrderByDescending(bb => bb.BiddingTime).FirstOrDefault().Bidder_ID : 0,
                        TicksRemain =  (i.Auctions.Last().Biddings.Count() > 0) ? (AuctionFeature.Commands.AddBidToAuctionCommand.AuctionTimeOut - 
                                    (int)(DateTime.Now - i.Auctions.Last().Biddings.OrderByDescending(bb => bb.BiddingTime).FirstOrDefault().BiddingTime).TotalSeconds) : 0,
                        history = ( i.Auctions.Last().Biddings.Count() > 0) ? i.Auctions.Last().Biddings.Select(b => new AuctionItemHistoryViewModel()
                        {
                            bid = b.BidValue,
                            name = b.Bidder.BidderName
                        }).ToArray() : null
                   ,
                        id = i.Auctions.Last().Id,
                        lastBid = (i.Auctions.Last().Biddings.Count() > 0) ? i.Auctions.Last().Biddings.OrderByDescending(bb => bb.BiddingTime).FirstOrDefault().BidValue : i.Price



                    }).ToArray();
                    return res.FirstOrDefault();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message + ex.StackTrace);
                    return null;
                }

            }
        }
    }
}
