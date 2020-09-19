using System;
using System.Collections.Generic;

namespace AuctionWeb.Domain.Entities
{
    public class AuctionBidding : BaseEntity
    {
        public AuctionBidding()
        {
             
        }
        public int Auction_ID { get; set; }

        public int Bidder_ID { get; set; }
        public DateTime    BiddingTime  { get; set; }

        public decimal BidValue { get; set; }
        public Bidder Bidder { get; set; }
        public Auction Auction { get; set; }

    }
}
