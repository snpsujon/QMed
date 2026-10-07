using Dapper;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository.BaseRepository;
using QuickMedProtal.ViewModels;
using System.Data;

namespace QuickMedProtal.ServiceRepository
{
    public class DosageService : BaseRepository<DosageVM>, IDosage
    {
        private readonly DapperContext _dapperContext;
        public DosageService(EFContext context, DapperContext dapperContext, IConfiguration configuration) : base(context, dapperContext, configuration)
        {
            _dapperContext = dapperContext;
        }

        public async Task<dynamic> GetDosageListData()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 1);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Dosage", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<dynamic> SaveDosageData(DosageVM data)
        {
            try
            {
                var parameters = new DynamicParameters();
                if (data.Id == null)
                {
                    var id = Guid.NewGuid();
                    parameters.Add("@Id", id);
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
                    var query = await _dp.QueryAsync<dynamic>("SP_Dosage", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex; // Consider logging the exception for better debugging
            }
        }


        public async Task<dynamic> DeleteDosageData(string id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 4);
                parameters.Add("@Id", id);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Dosage", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<dynamic> SearchDosage(string querystring)
        {
            try
            {
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>($"SELECT * FROM DrugDosage  WHERE Name LIKE '%{querystring}%';");
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
