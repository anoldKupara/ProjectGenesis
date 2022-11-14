namespace ProjectGenesis.Models.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string SourceOfFund { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
    }
}
