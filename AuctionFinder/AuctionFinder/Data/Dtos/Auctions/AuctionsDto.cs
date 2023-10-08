using AuctionFinder.Data.Entities;
using System.Collections.Specialized;

namespace AuctionFinder.Data.Dtos.Auctions
{
    public record AuctionDto(int Id, string Name, string Description, DateTime StartDate, DateTime EndDate, Category Category);
    public record CreateAuctionDto(string Name, string Description, DateTime StartDate, DateTime EndDate);
    public record UpdateAuctionDto(string Name, string Description, DateTime EndDate);
}
