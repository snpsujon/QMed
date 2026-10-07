using Dapper;
using QuickMedPortal.ViewModels;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository.BaseRepository;
using System.Data;

namespace QuickMedProtal.ServiceRepository
{
    public class DashBoardServicecs : BaseRepository<TotalInfoVm>, IDashboard
    {
        public DashBoardServicecs(EFContext context, DapperContext dapperContext, IConfiguration configuration) : base(context, dapperContext, configuration)
        {
        }

        public async Task<dynamic> GetAllDashboardData(TotalInfoVm data)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 1);
                parameters.Add("@StartDate", data.StartDate);
                parameters.Add("@EndDate", data.EndDate);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryFirstOrDefaultAsync<dynamic>("SP_Dashboard", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<dynamic> GetAllDashboardDoctorData()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 2);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryFirstOrDefaultAsync<dynamic>("SP_Dashboard", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<dynamic> InsertDatasToTable(string? responseMedicineDataAsJSON, string? responseTypeDataAsJSON, string? responseGenericDataAsJSON, string? responseDosageDataAsJSON, string? responseManufacturerDataAsJSON)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 3);
                parameters.Add("@csvMedicine", responseMedicineDataAsJSON);
                parameters.Add("@csvType", responseTypeDataAsJSON);
                parameters.Add("@csvDose", responseDosageDataAsJSON);
                parameters.Add("@csvGeneric", responseGenericDataAsJSON);
                parameters.Add("@csvManufacturer", responseManufacturerDataAsJSON);

                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryFirstOrDefaultAsync<dynamic>("SpProcessCSV", parameters, commandType: CommandType.StoredProcedure);
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
