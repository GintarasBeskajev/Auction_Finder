using AuctionFinder.Auth.Model;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace AuctionFinder.Data.Entities
{
    public class Category : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
        public AuctionFinderUser User { get; set; }
    }
}
