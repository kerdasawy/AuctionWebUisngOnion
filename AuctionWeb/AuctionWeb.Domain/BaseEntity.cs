using System.ComponentModel.DataAnnotations;

namespace AuctionWeb.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
