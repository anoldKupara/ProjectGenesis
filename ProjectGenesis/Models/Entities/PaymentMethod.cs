namespace ProjectGenesis.Models.Entities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
    }
}
