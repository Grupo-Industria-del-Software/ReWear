namespace Domain.Common
{
    public abstract class EntityCatalog
    {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
