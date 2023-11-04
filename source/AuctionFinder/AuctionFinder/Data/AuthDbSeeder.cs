using AuctionFinder.Auth.Model;
using Microsoft.AspNetCore.Identity;

namespace AuctionFinder.Data
{
    public class AuthDbSeeder
    {
        private readonly UserManager<AuctionFinderUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthDbSeeder(UserManager<AuctionFinderUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await AddDefaultRoles();
            await AddAdminUser();
        }

        private async Task AddDefaultRoles()
        {
            foreach (var role in AuctionFinderRoles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);

                if (!roleExists) 
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                } 
            }
        }

        private async Task AddAdminUser()
        {
            var newAdminUser = new AuctionFinderUser
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };

            var existingAdmin = await _userManager.FindByNameAsync(newAdminUser.UserName);

            if (existingAdmin == null)
            {
                var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "AdminPassword1!");
                if (createAdminUserResult.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newAdminUser, AuctionFinderRoles.All);
                }
            }
        }
    }
}
