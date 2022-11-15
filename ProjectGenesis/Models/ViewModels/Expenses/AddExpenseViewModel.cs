namespace ProjectGenesis.Models.ViewModels.Expenses
{
    public class AddExpenseViewModel
    {
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string SourceOfFund { get; set; }
        public DateTime ExpenseDate { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
    }
}
