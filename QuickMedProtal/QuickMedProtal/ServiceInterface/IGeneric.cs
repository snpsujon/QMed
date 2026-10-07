using QuickMedProtal.ViewModels;

namespace QuickMedProtal.ServiceInterface
{
    public interface IGeneric
    {
        Task<dynamic> GetGenericListData();
        Task<dynamic> SaveGenericData(GenericVM data);
        Task<dynamic> DeleteGenericData(string id);
        Task<dynamic> SearchGenerics(string querystring);
    }
}
