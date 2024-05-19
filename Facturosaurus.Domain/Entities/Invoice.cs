
namespace Facturosaurus.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CustomerName { get; set; } = "";
        public string CustomerNipNumber { get; set; } = "";
        public string CustomerStreetName { get; set; } = "";
        public string CustomerBildingNumber { get; set; } = "";
        public string CustomerApartmentNumber { get; set; } = "";
        public string CustomerZipCode { get; set; } = "";
        public string CustomerCity { get; set; } = "";
        public decimal NetAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal VatAmount { get; set; }
        public bool Paid { get; set; }
        public DateTime PaidDate { get; set; }
        public string CorrectionReason { get; set; } = "";
        public string Author { get; set; } = "";

        public int CompanyDetailsId { get; set; }
        public virtual CompanyDetails CompanyDetails { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int? CorrectionId { get; set; }
        public virtual Invoice? Correction { get; set; }

        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }

        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public virtual List<InvoiceItems> Items { get; set; } = [];
    }
}
