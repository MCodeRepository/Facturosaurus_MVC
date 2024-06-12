namespace Facturosaurus.Application.TaxTypes.Queries
{
    public class TaxTypeDto
    {
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public string Name { get; set; } = "";
        public bool Active { get; set; }
    }
}
