using AuctionFinder.Auth;
using AuctionFinder.Auth.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuctionFinder.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AuctionFinderUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(UserManager<AuctionFinderUser> userManager, IJwtTokenService jwtTokenService) 
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.FindByNameAsync(registerUserDto.UserName);

            if (user != null) 
            { 
                return BadRequest("Request invalid"); 
            }

            var newUser = new AuctionFinderUser
            {
                Email = registerUserDto.Email,
                UserName = registerUserDto.UserName
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Password);

            if (!createUserResult.Succeeded)
            {
                return BadRequest("Could not create a user.");
            }

            await _userManager.AddToRoleAsync(newUser, AuctionFinderRoles.AuctionUser);

            return CreatedAtAction(nameof(Register), new UserDto(newUser.Id, newUser.UserName, newUser.Email));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null)
            {
                return BadRequest("Username or password is incorrect");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Username or password is incorrect");
            }

            user.ForceRelogin = false;
            await _userManager.UpdateAsync(user);

            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);
            var refreshToken = _jwtTokenService.CreateRefreshToken(user.Id);

            return Ok(new SuccessfulLoginDto(accessToken, refreshToken));
        }

        [HttpPost]
        [Route("accessToken")]
        public async Task<IActionResult> Refresh(RefreshAccessTokenDto refreshAccessTokenDto)
        {
            if (!_jwtTokenService.TryParseRefreshToken(refreshAccessTokenDto.RefreshToken, out var claims))
            {
                return UnprocessableEntity();
            }

            var userId = claims.FindFirstValue(JwtRegisteredClaimNames.Sub);

            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return UnprocessableEntity("Invalid token");
            }

            if (user.ForceRelogin)
            {
                return UnprocessableEntity();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _jwtTokenService.CreateAccessToken(user.UserName, user.Id, roles);
            var refreshToken = _jwtTokenService.CreateRefreshToken(user.Id);

            return Ok(new SuccessfulLoginDto(accessToken, refreshToken));
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout(RefreshAccessTokenDto refreshAccessTokenDto)
        {
            if (!_jwtTokenService.TryParseRefreshToken(refreshAccessTokenDto.RefreshToken, out var claims))
            {
                return UnprocessableEntity();
            }

            var userId = claims.FindFirstValue(JwtRegisteredClaimNames.Sub);

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return UnprocessableEntity("Invalid token");
            }

            if (user.ForceRelogin)
            {
                return UnprocessableEntity();
            }

            user.ForceRelogin = true;
            await _userManager.UpdateAsync(user);

            return Ok("Logout successful");
        }
    }
}
