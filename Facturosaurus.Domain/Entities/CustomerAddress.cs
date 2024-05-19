namespace Facturosaurus.Domain.Entities
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string StreetName { get; set; } = "";
        public string BildingNumber { get; set; } = "";
        public string? ApartmentNumber { get; set; }
        public string ZipCode { get; set; } = "";
        public string City { get; set; } = "";
        public bool Default { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
