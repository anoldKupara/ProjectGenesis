namespace ProjectGenesis.Models.ViewModels.Inventories
{
    public class AddInventoryViewModel
    {
        public string ItemName { get; set; }
        public string Purpose { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
