using AuctionFinder.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionFinder.Data
{
    public class AuctionsDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=AuctionsDb");
        }
    }
}
