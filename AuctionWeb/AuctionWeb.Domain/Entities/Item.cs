using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionWeb.Domain.Entities
{
    public class Item : BaseEntity
    {
        public Item()
        {
            Auctions = new List<Auction>();
        }
        public string ItemName { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

       
        public virtual Bidder Bidder { get; set; }
        [ForeignKey("Bidder")]
        public int? BidderID { get; set; }
        public   List<Auction >Auctions { get; set; }
    }
}
