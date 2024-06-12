namespace Facturosaurus.Domain.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
