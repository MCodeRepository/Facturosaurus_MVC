

namespace Facturosaurus.Application.Invoices
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Number { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CompanyDetailsId { get; set; }
        public string ShortCompanyName { get; set; }
        public string CompanyName { get; set; }
        public string NipNumber { get; set; }
        public string StreetName { get; set; }
        public string BildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string BankName { get; set; }
        public string Currency { get; set; }
        public string BankAccountNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressEmail { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNipNumber { get; set; }
        public string CustomerStreetName { get; set; }
        public string CustomerBildingNumber { get; set; }
        public string CustomerApartmentNumber { get; set; }
        public string CustomerZipCode { get; set; }
        public string CustomerCity { get; set; }
        public decimal NetAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal VatAmount { get; set; }
        public bool Paid { get; set; }
        public DateTime PaidDate { get; set; }
        public Guid UserId { get; set; }
        public string Author { get; set; }

        public List<InvoiceItemDto> Items { get; set; }
    }
}
