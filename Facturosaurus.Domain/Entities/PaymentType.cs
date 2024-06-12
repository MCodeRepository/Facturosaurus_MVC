namespace Facturosaurus.Domain.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int DaysToAddToDatePayment { get; set; }
        public bool Active { get; set; }
    }
}
