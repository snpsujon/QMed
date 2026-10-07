namespace QuickMedProtal.ViewModels
{
    public class BrandVM
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? DosageId { get; set; }
        public Guid? GenericId { get; set; }
        public string? Strength { get; set; }
        public Guid? ManufacturerId { get; set; }
        public string? PackageContainer { get; set; }
        public string? PackageSize { get; set; }
        public bool? IsSynced { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
