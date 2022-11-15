namespace ProjectGenesis.Models.ViewModels.Vaccines
{
    public class AddVaccineViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Purpose { get; set; }
        public string Alternative { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
    }
}
