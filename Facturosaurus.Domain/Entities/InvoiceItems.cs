namespace Facturosaurus.Domain.Entities
{
    public class InvoiceItems
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string ItemName { get; set; }
        public int Unit { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetValue { get; set; }
        public Vat Vat { get; set; }
        public decimal VatValue { get; set; }
        public decimal GrossValue { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
    }
}
