using AuctionFinder.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionFinder.Data.Repositories
{
    public interface ICategoriesRepository
    {
        Task<Category?> GetSingleAsync(int categoryId);
        Task<IReadOnlyList<Category>> GetManyAsync();
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AuctionsDbContext _auctionsDbContext;
        public CategoriesRepository(AuctionsDbContext auctionsDbContext)
        {
            _auctionsDbContext = auctionsDbContext;
        }

        public async Task<Category?> GetSingleAsync(int categoryId)
        {
            return await _auctionsDbContext.Categories.FirstOrDefaultAsync(entry => entry.Id == categoryId);
        }

        public async Task<IReadOnlyList<Category>> GetManyAsync()
        {
            return await _auctionsDbContext.Categories.ToListAsync();
        }

        public async Task CreateAsync(Category category)
        {
            _auctionsDbContext.Categories.Add(category);
            await _auctionsDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _auctionsDbContext.Categories.Update(category);
            await _auctionsDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _auctionsDbContext.Categories.Remove(category);
            await _auctionsDbContext.SaveChangesAsync();
        }
    }
}
