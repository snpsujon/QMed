using QuickMedProtal.ServiceInterface.BaseInterface;
using QuickMedProtal.ViewModels;

namespace QuickMedProtal.ServiceInterface
{
    public interface IDosage : IBaseInterface<DosageVM>
    {
        Task<dynamic> GetDosageListData();
        Task<dynamic> SaveDosageData(DosageVM data);
        Task<dynamic> DeleteDosageData(string id);
        Task<dynamic> SearchDosage(string querystring);
    }
}
