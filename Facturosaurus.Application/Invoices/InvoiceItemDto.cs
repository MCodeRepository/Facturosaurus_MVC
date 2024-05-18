namespace Facturosaurus.Application.Invoices
{
    public class InvoiceItemDto
    {
        public int OrderNumber { get; set; }
        public string ItemName { get; set; }
        public int Unit { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetValue { get; set; }
       //// public Vat Vat { get; set; }
        //public string VatName { get; set; }
        //public decimal VatRate { get; set; }
        public decimal VatValue { get; set; }
        public decimal GrossValue { get; set; }
    }
}
