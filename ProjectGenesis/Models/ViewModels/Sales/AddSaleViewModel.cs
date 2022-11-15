namespace ProjectGenesis.Models.ViewModels.Sales
{
    public class AddSaleViewModel
    {
        public string ItemPurchased { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
