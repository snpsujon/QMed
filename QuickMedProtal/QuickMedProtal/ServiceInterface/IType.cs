using QuickMedProtal.ServiceInterface.BaseInterface;
using QuickMedProtal.ViewModels;

namespace QuickMedProtal.ServiceInterface
{
    public interface IType : IBaseInterface<TypeVM>

    {
        Task<dynamic> GetTypeListData();
        Task<dynamic> SaveTypeData(TypeVM data);
        Task<dynamic> DeleteTypeData(string id);
        Task<dynamic> SearchType(string querystring);
    }
}
