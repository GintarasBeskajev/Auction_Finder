using AuctionFinder.Data.Dtos.Auctions;
using AuctionFinder.Data.Dtos.Categories;
using AuctionFinder.Data.Entities;
using AuctionFinder.Data.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace AuctionFinder.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/auctions")]
    public class AuctionsController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IAuctionsRepository _auctionsRepository;
        public AuctionsController(ICategoriesRepository categoriesRepository, IAuctionsRepository auctionsRepository)
        {
            _categoriesRepository = categoriesRepository;
            _auctionsRepository = auctionsRepository;
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

            return auctions.Select(entity => new AuctionDto(entity.Id, entity.Name,
                entity.Description, entity.StartDate, entity.EndDate, entity.Category)).ToList();
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

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            return new AuctionDto(auction.Id, auction.Name, auction.Description, 
                auction.StartDate, auction.EndDate, auction.Category);
        }

        [HttpPost]
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

            if (createAuctionDto.StartDate < DateTime.Now || createAuctionDto.EndDate < DateTime.Now)
            {
                return UnprocessableEntity();
            }

            if (createAuctionDto.EndDate <= createAuctionDto.StartDate)
            {
                return UnprocessableEntity();
            }

            var auction = new Auction { Name = createAuctionDto.Name, Description = createAuctionDto.Description, 
                StartDate = createAuctionDto.StartDate, EndDate = createAuctionDto.EndDate, Category = category };

            await _auctionsRepository.CreateAsync(auction);

            return CreatedAtAction("GetAuction", new { categoryId = category.Id, auctionId = auction.Id }, new AuctionDto(auction.Id, 
                auction.Name, auction.Description, auction.StartDate, auction.EndDate, auction.Category));
        }

        [HttpPut]
        [Route("{auctionId}")]
        public async Task<ActionResult<AuctionDto>> Update(int categoryId, int auctionId, UpdateAuctionDto updateAuctionDto)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
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
        public async Task<ActionResult> Remove(int categoryId, int auctionId)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var auction = await _auctionsRepository.GetSingleAsync(auctionId);

            if (auction == null)
            {
                return NotFound();
            }

            await _auctionsRepository.DeleteAsync(auction);

            return NoContent();
        }
    }
}
