using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionWeb.Domain.Entities
{
     public class BidderAuction : BaseEntity
    {
        public BidderAuction()
        {
            
        }
        public  Bidder  Bidders{ get; set; }

        public  Auction  Auctions { get; set; }

    }
}

