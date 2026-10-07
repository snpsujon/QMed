using QuickMedProtal.ViewModels;

namespace QuickMedProtal.ServiceInterface
{
    public interface IDoctor
    {
        Task<dynamic> SaveDoctorData(DoctorVM data);
        Task<dynamic> DeleteDoctorData(string id);
    }
}
