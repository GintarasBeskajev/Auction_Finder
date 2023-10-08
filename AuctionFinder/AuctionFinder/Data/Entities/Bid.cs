namespace AuctionFinder.Data.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        public double BidSize { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }

        public Auction Auction { get; set; }
    }
}
