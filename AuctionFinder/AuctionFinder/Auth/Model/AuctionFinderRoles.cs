namespace AuctionFinder.Auth.Model
{
    public static class AuctionFinderRoles
    {
        public const string Admin = nameof(Admin);
        public const string AuctionUser = nameof(AuctionUser);

        public static readonly IReadOnlyCollection<string> All = new[] { Admin, AuctionUser };
    }
}
