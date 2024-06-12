namespace Facturosaurus.Domain.Entities
{
    public class InvoiceItems
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string ItemName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetValue { get; set; }
        public decimal VatValue { get; set; }
        public decimal GrossValue { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        public int UnitTypeId { get; set; }
        public virtual UnitType UnitType { get; set; }

        public int TaxTypeId { get; set; }
        public virtual TaxType TaxType { get; set; }
    }

}
