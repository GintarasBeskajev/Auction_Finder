using AuctionFinder.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace AuctionFinder.Data.Entities
{
    public class FinalBid
    {
        public int Id { get; set; }
        public double BidSize { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }

        public Auction Auction { get; set; }

        [Required]
        public string UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
