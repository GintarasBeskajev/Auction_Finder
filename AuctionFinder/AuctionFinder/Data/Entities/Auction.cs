using AuctionFinder.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace AuctionFinder.Data.Entities
{
    public class Auction : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Category Category { get; set; }

        [Required]
        public string UserId { get; set; }
        public AuctionFinderUser User { get; set; }
    }
}
