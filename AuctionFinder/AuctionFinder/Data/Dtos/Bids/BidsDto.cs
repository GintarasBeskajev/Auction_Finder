using AuctionFinder.Data.Entities;
using System.Collections.Specialized;

namespace AuctionFinder.Data.Dtos.Bids
{
    public record BidDto(int Id, double BidSize, string Comment, DateTime CreationDate, Auction Auction, string UserId);
    public record GetBidDto(int Id, double BidSize, string Comment, DateTime CreationDate, Auction Auction, string UserId, string UserEmail);
    public record CreateBidDto(double BidSize, string Comment, DateTime CreationDate);
    public record UpdateBidDto(string Comment);
}
