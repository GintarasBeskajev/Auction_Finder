using AuctionFinder.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace AuctionFinder.Data.Repositories
{
    public interface IBidsRepository
    {
        Task CreateAsync(Bid bid);
        Task DeleteAsync(Bid bid);
        Task<IReadOnlyList<Bid>> GetManyAsync();
        Task<Bid?> GetSingleAsync(int bidId);
        Task UpdateAsync(Bid bid);
    }

    public class BidsRepository : IBidsRepository
    {
        private readonly AuctionsDbContext _auctionsDbContext;
        public BidsRepository(AuctionsDbContext auctionsDbContext)
        {
            _auctionsDbContext = auctionsDbContext;
        }

        public async Task<Bid?> GetSingleAsync(int bidId)
        {
            return await _auctionsDbContext.Bids.FirstOrDefaultAsync(entry => entry.Id == bidId);
        }

        public async Task<IReadOnlyList<Bid>> GetManyAsync()
        {
            return await _auctionsDbContext.Bids.ToListAsync();
        }

        public async Task CreateAsync(Bid bid)
        {
            _auctionsDbContext.Bids.Add(bid);
            await _auctionsDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bid bid)
        {
            _auctionsDbContext.Bids.Update(bid);
            await _auctionsDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Bid bid)
        {
            _auctionsDbContext.Bids.Remove(bid);
            await _auctionsDbContext.SaveChangesAsync();
        }
    }
}
