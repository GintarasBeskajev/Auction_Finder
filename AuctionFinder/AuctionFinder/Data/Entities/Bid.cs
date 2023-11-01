using AuctionFinder.Auth.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;

namespace AuctionFinder.Data.Entities
{
    public class Bid : IUserOwnedResource
    {
        public int Id { get; set; }
        public double BidSize { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }

        public Auction Auction { get; set; }

        [Required]
        public string UserId { get; set; }
        public AuctionFinderUser User { get; set; }
    }
}
