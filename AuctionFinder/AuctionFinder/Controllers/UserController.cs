using AuctionFinder.Auth.Model;
using AuctionFinder.Data.Dtos.Auctions;
using AuctionFinder.Data.Dtos.Bids;
using AuctionFinder.Data.Dtos.Categories;
using AuctionFinder.Data.Entities;
using AuctionFinder.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuctionFinder.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IBidsRepository _bidsRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<AuctionFinderUser> _userManager;

        public UserController(UserManager<AuctionFinderUser> userManager, ICategoriesRepository categoriesRepository, IAuctionsRepository auctionsRepository, IBidsRepository bidsRepository, IAuthorizationService authorizationService)
        {
            _categoriesRepository = categoriesRepository;
            _auctionsRepository = auctionsRepository;
            _bidsRepository = bidsRepository;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }

        [Route("auctions")]
        [HttpGet]
        [Authorize(Roles = AuctionFinderRoles.AuctionUser)]
        public async Task<ActionResult<List<AuctionDto>>> GetAuctions()
        {
            var categories = await _categoriesRepository.GetManyAsync();
            var auctions = await _auctionsRepository.GetManyAsync();

            return auctions.Where(entity => entity.UserId == User.FindFirstValue(JwtRegisteredClaimNames.Sub)).Select(entity => new AuctionDto(entity.Id, entity.Name,
                entity.Description, entity.StartDate, entity.EndDate, entity.Category, entity.UserId)).ToList();
        }

        [Route("bids")]
        [HttpGet]
        [Authorize(Roles = AuctionFinderRoles.AuctionUser)]
        public async Task<ActionResult<List<GetBidDto>>> GetMany()
        {
            var categories = await _categoriesRepository.GetManyAsync();
            var auctions = await _auctionsRepository.GetManyAsync();
            var bids = await _bidsRepository.GetManyAsync();
            List<FinalBid> finalBids = new List<FinalBid>();

            foreach (var bid in bids)
            {
                var user = await _userManager.FindByIdAsync(bid.UserId);

                FinalBid finalBid = new FinalBid();
                finalBid.Id = bid.Id;
                finalBid.BidSize = bid.BidSize;
                finalBid.Comment = bid.Comment;
                finalBid.CreationDate = bid.CreationDate;
                finalBid.Auction = bid.Auction;
                finalBid.UserId = bid.UserId;
                finalBid.UserEmail = user.Email;

                finalBids.Add(finalBid);
            }


            return finalBids.Where(entity => entity.UserId == User.FindFirstValue(JwtRegisteredClaimNames.Sub)).Select(entity => new GetBidDto(entity.Id, entity.BidSize, entity.Comment, entity.CreationDate,
                entity.Auction, entity.UserId, entity.UserEmail)).ToList();
        }
    }
}

