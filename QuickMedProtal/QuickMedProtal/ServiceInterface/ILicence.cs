using QuickMedProtal.ViewModels;

namespace QuickMedProtal.ServiceInterface
{
    public interface ILicence 
    {
        Task<dynamic> GetLicenceInfo();
        Task<dynamic> GetLicenceKeydata();
        Task<dynamic> SaveLicenceData(LicenceVm data);
        Task<dynamic> DeleteLicenceData(string id);
        Task<dynamic> GetLicenseData();
        Task<dynamic> CheckValidity(LicenseValidity data);
    }
}
