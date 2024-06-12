namespace Facturosaurus.Application.PaymentTypes
{
    public class PaymentTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int DaysToAddToDatePayment { get; set; }
        public bool Active { get; set; }
    }
}
