namespace ProjectGenesis.Models.ViewModels.Feeds
{
    public class AddFeedViewModel
    {
        public string Name { get; set; }
        public string Purpose { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
        public string Supplier { get; set; }
        public int Quantity { get; set; }
    }
}
