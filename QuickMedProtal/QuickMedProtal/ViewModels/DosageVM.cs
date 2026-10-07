namespace QuickMedProtal.ViewModels
{
    public class DosageVM
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public bool? IsSynced { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
