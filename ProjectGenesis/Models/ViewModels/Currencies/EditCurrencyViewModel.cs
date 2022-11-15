namespace ProjectGenesis.Models.ViewModels.Currencies
{
    public class EditCurrencyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Rate { get; set; }
    }
}
