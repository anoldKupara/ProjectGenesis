namespace ProjectGenesis.Models.ViewModels.Currencies
{
    public class UpdateCurrencyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Rate { get; set; }
    }
}
