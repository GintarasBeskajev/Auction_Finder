using AuctionFinder.Data.Entities;
using System.Collections.Specialized;

namespace AuctionFinder.Data.Dtos.Bids
{
    public record BidDto(int Id, double BidSize, string Comment, DateTime CreationDate, Auction Auction);
    public record CreateBidDto(double BidSize, string Comment, DateTime CreationDate);
    public record UpdateBidDto(string Comment);
}
