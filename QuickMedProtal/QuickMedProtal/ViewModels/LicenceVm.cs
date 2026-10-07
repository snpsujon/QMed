namespace QuickMedProtal.ViewModels
{
    public class LicenceVm
    {
        public Guid? Id { get; set; }
        public string LicenseKey { get; set; } 
        public DateTime ExpirationDate { get; set; }      
        public string? LogInId { get; set; } 
        

    }
    public class LicenseValidity
    {
        public string LicenseKey { get; set; }
        //public bool IsValid { get; set; }
        //public DateTime? ExpirationDate { get; set; }
    }
}
