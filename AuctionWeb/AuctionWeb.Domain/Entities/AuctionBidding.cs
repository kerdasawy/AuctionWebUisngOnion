using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionWeb.Domain.Entities
{
    public class AuctionBidding : BaseEntity
    {
        public AuctionBidding()
        {
             
        }
        [ForeignKey("Auction")]
        public int Auction_ID { get; set; }
        [ForeignKey("Bidder")]
        public int Bidder_ID { get; set; }
        public DateTime    BiddingTime  { get; set; }

        public decimal BidValue { get; set; }
       
        public Bidder Bidder { get; set; }
        
        public Auction Auction { get; set; }

    }
}
