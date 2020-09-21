using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionWeb.Persistence.ViewModel
{
    public class AuctionItemViewModel
    {

        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal lastBid { get; set; }
        public AuctionItemHistoryViewModel[] history { get; set; }
        public int? bidder_ID { get; set; }
    }
    public class AuctionItemHistoryViewModel
    {


        public string name { get; set; }
        public decimal bid { get; set; }

    }
}
