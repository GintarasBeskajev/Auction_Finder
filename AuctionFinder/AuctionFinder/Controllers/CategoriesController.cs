using AuctionFinder.Data.Dtos.Auctions;
using AuctionFinder.Data.Dtos.Categories;
using AuctionFinder.Data.Entities;
using AuctionFinder.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuctionFinder.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository) 
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetMany()
        {
            var categories = await _categoriesRepository.GetManyAsync();

            return categories.Select(entity => new CategoryDto(entity.Id, entity.Name));
        }

        [HttpGet]
        [Route("{categoryId}"), ActionName("GetCategory")]
        public async Task<ActionResult<CategoryDto>> GetSingle(int categoryId)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if(category == null)
            {
                return NotFound();  
            }

            return new CategoryDto(category.Id, category.Name);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createCategoryDto)
        {
            if (string.IsNullOrWhiteSpace(createCategoryDto.Name))
            {
                return UnprocessableEntity();
            }

            if (createCategoryDto.Name.Length < 2 || createCategoryDto.Name.Length > 100)
            {
                return UnprocessableEntity();
            }

            var category = new Category { Name = createCategoryDto.Name };

            await _categoriesRepository.CreateAsync(category);

            return CreatedAtAction("GetCategory", new { categoryId = category.Id }, new CategoryDto(category.Id, category.Name));
        }

        [HttpPut]
        [Route("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> Update(int categoryId, UpdateCategoryDto updateCategoryDto)
        {
            if (string.IsNullOrWhiteSpace(updateCategoryDto.Name))
            {
                return UnprocessableEntity(updateCategoryDto.Name);
            }

            if (string.IsNullOrWhiteSpace(updateCategoryDto.Name))
            {
                return UnprocessableEntity();
            }

            if (updateCategoryDto.Name.Length < 2 || updateCategoryDto.Name.Length > 100)
            {
                return UnprocessableEntity();
            }

            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = updateCategoryDto.Name;
            await _categoriesRepository.UpdateAsync(category);

            return Ok(new CategoryDto(category.Id, category.Name));
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public async Task<ActionResult> Remove(int categoryId)
        {
            var category = await _categoriesRepository.GetSingleAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            await _categoriesRepository.DeleteAsync(category);

            return NoContent(); 
        }
    }
}
