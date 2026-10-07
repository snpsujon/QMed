using Dapper;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository.BaseRepository;
using QuickMedProtal.ViewModels;
using System.Data;

namespace QuickMedProtal.ServiceRepository
{
    public class CompanyService : BaseRepository<CompanyVM>, ICompany
    {
        public CompanyService(EFContext context, DapperContext dapperContext, IConfiguration configuration) : base(context, dapperContext, configuration)
        {
        }

        public async Task<dynamic> GetCompanyListData()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 1);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Company", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<dynamic> SaveCompanyData(CompanyVM data)
        {
            try
            {
                var parameters = new DynamicParameters();
                if (data.Id == null)
                {
                    parameters.Add("@Flag", 2); // Flag for insert
                    parameters.Add("@Name", data.Name);
                }
                else
                {
                    parameters.Add("@Id", data.Id);
                    parameters.Add("@Flag", 3); // Flag for update
                    parameters.Add("@Name", data.Name);
                }

                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Company", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex; // Consider logging the exception for better debugging
            }
        }


        public async Task<dynamic> DeleteCompanyData(string id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 4);
                parameters.Add("@Id", id);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Company", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<dynamic> SearchCompany(string querystring)
        {
            try
            {
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>($"SELECT * FROM TblCompany  WHERE Name LIKE '%{querystring}%';");
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
