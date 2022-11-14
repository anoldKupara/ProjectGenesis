namespace ProjectGenesis.Models.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public string ItemPurchased { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DateOfPurchase { get; set; }

    }
}
