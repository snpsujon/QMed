using QuickMedProtal.ViewModels;

namespace QuickMedProtal.ServiceInterface
{
    public interface ICompany
    {
        Task<dynamic> GetCompanyListData();
        Task<dynamic> SaveCompanyData(CompanyVM data);
        Task<dynamic> DeleteCompanyData(string id);
        Task<dynamic> SearchCompany(string querystring);

    }
}
