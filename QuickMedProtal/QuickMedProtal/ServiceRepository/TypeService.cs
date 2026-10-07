using Dapper;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository.BaseRepository;
using QuickMedProtal.ViewModels;
using System.Data;

namespace QuickMedProtal.ServiceRepository
{
    public class TypeService : BaseRepository<TypeVM>, IType
    {
        public TypeService(EFContext context, DapperContext dapperContext, IConfiguration configuration) : base(context, dapperContext, configuration)
        {
        }

        public async Task<dynamic> GetTypeListData()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 1);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Type", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<dynamic> SaveTypeData(TypeVM data)
        {
            try
            {
                var parameters = new DynamicParameters();
                if (data.Id == null)
                {
                    var id = Guid.NewGuid();
                    parameters.Add("@Flag", 2); // Flag for insert
                    parameters.Add("@Name", data.Name);
                    parameters.Add("@Id", id);
                }
                else
                {
                    parameters.Add("@Id", data.Id);
                    parameters.Add("@Flag", 3); // Flag for update
                    parameters.Add("@Name", data.Name);
                }

                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Type", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex; // Consider logging the exception for better debugging
            }
        }


        public async Task<dynamic> DeleteTypeData(string id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 4);
                parameters.Add("@Id", id);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Type", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<dynamic> SearchType(string querystring)
        {
            try
            {
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>($"SELECT * FROM DrugType  WHERE Name LIKE '%{querystring}%';");
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
