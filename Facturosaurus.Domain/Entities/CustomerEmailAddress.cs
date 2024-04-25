namespace Facturosaurus.Domain.Entities
{
    public class CustomerEmailAddress
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string AddressEmail { get; set; }
        public bool Default { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}