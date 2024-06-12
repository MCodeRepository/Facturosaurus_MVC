namespace Facturosaurus.Domain.Entities
{
    public class UnitType
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = "";
        public string Name { get; set; } = "";
        public bool Active { get; set; }
    }
}
