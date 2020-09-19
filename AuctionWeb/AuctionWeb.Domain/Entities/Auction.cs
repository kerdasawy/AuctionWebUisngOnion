using System;
using System.Collections.Generic;

namespace AuctionWeb.Domain.Entities
{
    public class Auction : BaseEntity
    {
        public Auction()
        {
            Bidders = new List<BidderAuction>();
        }
        public int Item_ID{ get; set; }

        public Item Item { get; set; }
        public DateTime  StartDate { get; set; }
        public List<BidderAuction> Bidders { get; set; }


    }
}
