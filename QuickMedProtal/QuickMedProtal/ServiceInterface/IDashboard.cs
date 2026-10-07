using QuickMedPortal.ViewModels;

namespace QuickMedProtal.ServiceInterface
{
    public interface IDashboard
    {
        Task<dynamic> GetAllDashboardData(TotalInfoVm data);

        Task<dynamic> GetAllDashboardDoctorData();
        Task<dynamic> InsertDatasToTable(string? responseMedicineDataAsJSON, string? responseTypeDataAsJSON, string? responseGenericDataAsJSON, string? responseDosageDataAsJSON, string? responseManufacturerDataAsJSON);

    }
}
