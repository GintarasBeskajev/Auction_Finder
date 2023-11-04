using Microsoft.AspNetCore.Identity;

namespace AuctionFinder.Auth.Model
{
    public class AuctionFinderUser : IdentityUser
    {
        public bool ForceRelogin { get; set; }
    }
}
