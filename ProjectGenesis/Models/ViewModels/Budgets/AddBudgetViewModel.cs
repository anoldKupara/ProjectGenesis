namespace ProjectGenesis.Models.ViewModels.Budgets
{
    public class AddBudgetViewModel
    {
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string SourceOfFund { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
    }
}
