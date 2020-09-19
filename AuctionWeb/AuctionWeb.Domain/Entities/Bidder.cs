using System.Collections.Generic;

namespace AuctionWeb.Domain.Entities
{
    public class Bidder : BaseEntity
    {
        public Bidder()
        {
            Auctions = new List<BidderAuction>();
        }
        public string BidderName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        
        public List<BidderAuction> Auctions { get; set; }
    }
}
