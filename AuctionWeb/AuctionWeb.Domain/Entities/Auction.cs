using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionWeb.Domain.Entities
{
    public class Auction : BaseEntity
    {
        public Auction()
        {
            Bidders = new List<BidderAuction>();
            Biddings = new List<AuctionBidding>();
        }
        [ForeignKey("Item")]
        public int Item_ID { get; set; }
       
        public virtual Item Item { get; set; }
        public DateTime  StartDate { get; set; }
        public   List<BidderAuction> Bidders { get; set; }
        public   List<AuctionBidding> Biddings { get; set; }

    }
}
