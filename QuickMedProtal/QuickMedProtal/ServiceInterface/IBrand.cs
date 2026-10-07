using QuickMedProtal.ViewModels;

namespace QuickMedProtal.ServiceInterface
{
    public interface IBrand
    {
        Task<dynamic> GetBrandListData();
        Task<dynamic> SaveBrandData(BrandVM data);
        Task<dynamic> DeleteBrandData(string id);
        Task<dynamic> SearchQuery(string query);
        Task<dynamic> GetDataById(string query);
    }
}
