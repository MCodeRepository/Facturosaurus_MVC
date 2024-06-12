namespace Facturosaurus.Application.UnitTypes.Queries
{
    public class UnitTypeDto
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = "";
        public string Name { get; set; } = "";
        public bool Active { get; set; }
    }
}
