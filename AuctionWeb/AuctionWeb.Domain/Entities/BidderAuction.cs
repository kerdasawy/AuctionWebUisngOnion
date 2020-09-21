using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AuctionWeb.Domain.Entities
{
     public class BidderAuction : BaseEntity
    {
        public BidderAuction()
        {
            
        }
        [ForeignKey("Bidders")]
        public int BidderID { get; set; }
        
        public  Bidder  Bidders{ get; set; }
        [ForeignKey("Auctions")]
        public int AuctionID { get; set; }
       
        public  Auction  Auctions { get; set; }

    }
}

