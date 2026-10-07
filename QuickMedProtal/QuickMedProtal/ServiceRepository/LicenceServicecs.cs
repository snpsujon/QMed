using Dapper;
using QuickMedPortal.ViewModels;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository.BaseRepository;
using QuickMedProtal.ViewModels;
using System.Data;
using System.Numerics;

namespace QuickMedProtal.ServiceRepository
{
    public class LicenceServicecs : BaseRepository<LicenceVm>, ILicence
    {
        public LicenceServicecs(EFContext context, DapperContext dapperContext, IConfiguration configuration) : base(context, dapperContext, configuration)
        {
        }

        public async Task<dynamic> GetLicenceInfo()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 1);

                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Licence", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<dynamic> GetLicenceKeydata()
        {
            try
            {
                DateTime now = DateTime.Now;
                return $"L-{now:ddMM-yyyy-HHmm-fff}";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<dynamic> SaveLicenceData(LicenceVm data)
        {
            try
            {
                var parameters = new DynamicParameters();
                if (data.Id == null)
                {
                    parameters.Add("@Flag", 2);
                    parameters.Add("@LicenseKey", data.LicenseKey);
                    parameters.Add("@ExpirationDate", data.ExpirationDate);
                    parameters.Add("@LogInId", data.LogInId);


                }
                else
                {
                    parameters.Add("@Id", data.Id);
                    parameters.Add("@Flag", 3);
                    parameters.Add("@ExpirationDate", data.ExpirationDate);
                    parameters.Add("@LogInId", data.LogInId);
                }

                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Licence", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> DeleteLicenceData(string id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 4);
                parameters.Add("@Id", id);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Licence", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<dynamic> CheckValidity(LicenseValidity data)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 6);
                parameters.Add("@LicenseKey", data.LicenseKey);

                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryFirstOrDefaultAsync<dynamic>("SP_Licence", parameters, commandType: CommandType.StoredProcedure);
                    if(query != null)
                    {
                        parameters.Add("@Flag", 7);
                        var Doctor = await _dp.QueryFirstOrDefaultAsync<dynamic>("SP_Licence", parameters, commandType: CommandType.StoredProcedure);
                        var returnData = new
                        {
                            status = 200,
                            message = "Success",
                            data = new
                            {
                                IsValid = query.IsValid,
                                ExpirationDate = query.ExpirationDate,
                                Doctor = Doctor,
                            }
                        };
                        return returnData;
                    }
                    else
                    {
                        var returnData = new
                        {
                            status = 200,
                            message = "Success",
                            data = new
                            {
                                IsValid = 0,
                            }
                        };
                        return returnData;
                    }
                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public async Task<dynamic> GetLicenseData()
		{
			try
			{
				var parameters = new DynamicParameters();
				parameters.Add("@Flag",5);

				using (var _dp = _dapperContext.CreateConnection())
				{
					var query = await _dp.QueryAsync<dynamic>("SP_Licence", parameters, commandType: CommandType.StoredProcedure);
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
