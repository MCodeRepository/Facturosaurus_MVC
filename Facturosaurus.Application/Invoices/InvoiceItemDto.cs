namespace Facturosaurus.Application.Invoices
{
    public class InvoiceItemDto
    {
        public int InvoiceId { get; set; }
        public int OrderNumber { get; set; }
        public string ItemName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetValue { get; set; }
        public decimal VatValue { get; set; }
        public decimal GrossValue { get; set; }
        
        // UnitType
        public int UnitTypeId { get; set; }
        public string UnitShortName { get; set; } = "";
        public string UnitName { get; set; } = "";

        //TaxType
        public int TaxTypeId { get; set; }
        public decimal TaxTypeRate { get; set; }
        public string TaxTypeName { get; set; } = "";
    }
}
