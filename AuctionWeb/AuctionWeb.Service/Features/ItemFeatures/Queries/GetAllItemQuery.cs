using MediatR;
using Microsoft.EntityFrameworkCore;
using AuctionWeb.Domain.Entities;
using AuctionWeb.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using AuctionWeb.Persistence.ViewModel;

namespace AuctionWeb.Service.Features.ItemFeature.Queries
{
    public class GetAllItemQuery : IRequest<IEnumerable<AuctionItemViewModel>>
    {

        public class GetAllItemQueryHandler : IRequestHandler<GetAllItemQuery, IEnumerable<AuctionItemViewModel>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllItemQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<AuctionItemViewModel>> Handle(GetAllItemQuery request, CancellationToken cancellationToken)
            {
                

                try
                {
                    await AuctionFeature.Commands.AddBidToAuctionCommand.checkAuctionTimes(_context);
                    var itemList = await _context.Items.Include(i=>i.Auctions).Include(i=>i.Bidder).ToListAsync();
                    //adding items to auction by defualt

                    //var endedAuctions = (from a in _context.Auctions
                    //                     join i in _context.Items on a.Item_ID equals i.Id
                    //                     join b in _context.AuctionBiddings on a.Id equals b.Auction_ID
                    //                     join bidder in _context.Bidders on b.Bidder_ID equals bidder.Id
                    //                     where !i.BidderID.HasValue
                    //                     select { }
                    //             );
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
                        history = ( i.Auctions.Last().Biddings.Count()>0)?i.Auctions.Last().Biddings.Select(b => new AuctionItemHistoryViewModel()
                        {
                            bid = b.BidValue,
                            name = _context.Bidders.Find( b.Bidder_ID).BidderName
                        }).ToArray():null
                   ,
                        id = i.Auctions.Last().Id,
                        lastBid = (i.Auctions.Last().Biddings.Count() > 0) ?  i.Auctions.Last().Biddings.OrderByDescending(bb => bb.BiddingTime).FirstOrDefault()?.BidValue ?? i.Price : i.Price



                    }).ToArray();
                    return res;
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
