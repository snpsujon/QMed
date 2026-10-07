using Dapper;
using Microsoft.AspNetCore.Identity;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository.BaseRepository;
using QuickMedProtal.ViewModels;
using System.Data;

namespace QuickMedProtal.ServiceRepository
{
    public class DemoService : BaseRepository<DemoVM>, IDemo
    {
        public DemoService(EFContext context, DapperContext dapperContext, IConfiguration configuration) : base(context, dapperContext, configuration)
        {
        }

        public async Task<dynamic> GetDemoData()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 1);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Demo", parameters, commandType: CommandType.StoredProcedure);
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
