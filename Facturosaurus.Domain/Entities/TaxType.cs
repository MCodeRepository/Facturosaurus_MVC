namespace Facturosaurus.Domain.Entities
{
    public class TaxType
    {
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public string Name { get; set; } = "";
        public bool Active { get; set; }
    }
}
