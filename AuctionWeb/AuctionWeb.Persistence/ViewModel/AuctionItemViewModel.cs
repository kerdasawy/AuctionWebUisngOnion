using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionWeb.Persistence.ViewModel
{
    public class AuctionItemViewModel
    {

        public int id { get; set; }
        public int Item_ID { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal lastBid { get; set; }
        public AuctionItemHistoryViewModel[] history { get; set; }
        public int? bidder_ID { get; set; }
        public string LastBidder { get; set; } ="";
        public int LastBidderID { get; set; } = 0;
        public int TicksRemain { get; set; } = 60;
    }
    public class AuctionItemHistoryViewModel
    {


        public string name { get; set; }
        public decimal bid { get; set; }

    }
}
