using AuctionFinder.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionFinder.Data.Repositories
{
    public interface IAuctionsRepository
    {
        Task CreateAsync(Auction auction);
        Task DeleteAsync(Auction auction);
        Task<IReadOnlyList<Auction>> GetManyAsync();
        Task<Auction?> GetSingleAsync(int auctionId);
        Task UpdateAsync(Auction auction);
    }

    public class AuctionsRepository : IAuctionsRepository
    {
        private readonly AuctionsDbContext _auctionsDbContext;
        public AuctionsRepository(AuctionsDbContext auctionsDbContext)
        {
            _auctionsDbContext = auctionsDbContext;
        }

        public async Task<Auction?> GetSingleAsync(int auctionId)
        {
            return await _auctionsDbContext.Auctions.FirstOrDefaultAsync(entry => entry.Id == auctionId);
        }

        public async Task<IReadOnlyList<Auction>> GetManyAsync()
        {
            return await _auctionsDbContext.Auctions.ToListAsync();
        }

        public async Task CreateAsync(Auction auction)
        {
            _auctionsDbContext.Auctions.Add(auction);
            await _auctionsDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Auction auction)
        {
            _auctionsDbContext.Auctions.Update(auction);
            await _auctionsDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Auction auction)
        {
            _auctionsDbContext.Auctions.Remove(auction);
            await _auctionsDbContext.SaveChangesAsync();
        }
    }
}
