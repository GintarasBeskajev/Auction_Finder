using AuctionFinder.Auth.Model;
using AuctionFinder.Data.Dtos.Auctions;
using AuctionFinder.Data.Dtos.Categories;
using AuctionFinder.Data.Entities;
using AuctionFinder.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuctionFinder.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/auctions")]
    public class AuctionsController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IAuthorizationService _authorizationService;

        public AuctionsController(ICategoriesRepository categoriesRepository, IAuctionsRepository auctionsRepository, IAuthorizationService authorizationService)
        {
            _categoriesRepository = categoriesRepository;
            _auctionsRepository = auctionsRepository;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuctionDto>>> GetMany(int categoryId)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auctions = await _auctionsRepository.GetManyAsync();

            return auctions.Where(entity => entity.Category == category).Select(entity => new AuctionDto(entity.Id, entity.Name,
                entity.Description, entity.StartDate, entity.EndDate, entity.Category, entity.UserId)).ToList();
        }

        [HttpGet]
        [Route("{auctionId}"), ActionName("GetAuction")]
        public async Task<ActionResult<AuctionDto>> GetSingle(int categoryId, int auctionId)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auctions = await _auctionsRepository.GetManyAsync();

            var currentAuctions = auctions.Where(entity => entity.Category == category)
                .Select(entity => new AuctionDto(entity.Id, entity.Name, entity.Description, entity.StartDate,
                entity.EndDate, entity.Category, entity.UserId)).ToList();

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            var currentAuctionContainment = currentAuctions.Where(entity => entity.Id == auction.Id).FirstOrDefault();

            if (currentAuctionContainment == null)
            {
                return NotFound();
            }

            return new AuctionDto(auction.Id, auction.Name, auction.Description,
                auction.StartDate, auction.EndDate, auction.Category, auction.UserId);
        }

        [HttpPost]
        [Authorize(Roles = AuctionFinderRoles.AuctionUser)]
        public async Task<ActionResult<AuctionDto>> Create(int categoryId, CreateAuctionDto createAuctionDto)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(createAuctionDto.Name))
            {
                return UnprocessableEntity();
            }

            if (createAuctionDto.Name.Length < 2 || createAuctionDto.Name.Length > 100)
            {
                return UnprocessableEntity();
            }

            if (string.IsNullOrWhiteSpace(createAuctionDto.Description))
            {
                return UnprocessableEntity();
            }

            if (createAuctionDto.Description.Length < 2 || createAuctionDto.Description.Length > 500)
            {
                return UnprocessableEntity();
            }

            if (createAuctionDto.EndDate <= createAuctionDto.StartDate)
            {
                return UnprocessableEntity();
            }

            var auction = new Auction
            {
                Name = createAuctionDto.Name,
                Description = createAuctionDto.Description,
                StartDate = createAuctionDto.StartDate,
                EndDate = createAuctionDto.EndDate,
                Category = category,
                UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
            };

            await _auctionsRepository.CreateAsync(auction);

            return CreatedAtAction("GetAuction", new { categoryId = category.Id, auctionId = auction.Id }, new AuctionDto(auction.Id,
                auction.Name, auction.Description, auction.StartDate, auction.EndDate, auction.Category, auction.UserId));
        }

        [HttpPut]
        [Route("{auctionId}")]
        [Authorize(Roles = AuctionFinderRoles.AuctionUser)]
        public async Task<ActionResult<AuctionDto>> Update(int categoryId, int auctionId, UpdateAuctionDto updateAuctionDto)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auctions = await _auctionsRepository.GetManyAsync();

            var currentAuctions = auctions.Where(entity => entity.Category == category)
                .Select(entity => new AuctionDto(entity.Id, entity.Name, entity.Description, entity.StartDate,
                entity.EndDate, entity.Category, entity.UserId)).ToList();

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            var currentAuctionContainment = currentAuctions.Where(entity => entity.Id == auction.Id).FirstOrDefault();

            if (currentAuctionContainment == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, auction, PolicyNames.ResourceOwner);
            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            if (string.IsNullOrWhiteSpace(updateAuctionDto.Name))
            {
                return UnprocessableEntity();
            }

            if (updateAuctionDto.Name.Length < 2 || updateAuctionDto.Name.Length > 100)
            {
                return UnprocessableEntity();
            }

            if (string.IsNullOrWhiteSpace(updateAuctionDto.Description))
            {
                return UnprocessableEntity();
            }

            if (updateAuctionDto.Description.Length < 2 || updateAuctionDto.Description.Length > 500)
            {
                return UnprocessableEntity();
            }

            auction.Name = updateAuctionDto.Name;
            auction.Description = updateAuctionDto.Description;
            auction.EndDate = updateAuctionDto.EndDate;
            await _auctionsRepository.UpdateAsync(auction);

            return Ok(new CategoryDto(auction.Id, auction.Name));
        }

        [HttpDelete]
        [Route("{auctionId}")]
        [Authorize(Roles = AuctionFinderRoles.AuctionUser)]
        public async Task<ActionResult> Remove(int categoryId, int auctionId)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auctions = await _auctionsRepository.GetManyAsync();

            var currentAuctions = auctions.Where(entity => entity.Category == category)
                .Select(entity => new AuctionDto(entity.Id, entity.Name, entity.Description, entity.StartDate,
                entity.EndDate, entity.Category, entity.UserId)).ToList();

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            var currentAuctionContainment = currentAuctions.Where(entity => entity.Id == auction.Id).FirstOrDefault();

            if (currentAuctionContainment == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, auction, PolicyNames.ResourceOwner);
            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            await _auctionsRepository.DeleteAsync(auction);

            return NoContent();
        }
    }
}