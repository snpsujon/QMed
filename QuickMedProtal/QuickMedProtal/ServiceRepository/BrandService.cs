using Dapper;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository.BaseRepository;
using QuickMedProtal.ViewModels;
using System.Data;

namespace QuickMedProtal.ServiceRepository
{
    public class BrandService : BaseRepository<BrandVM>, IBrand
    {
        public BrandService(EFContext context, DapperContext dapperContext, IConfiguration configuration) : base(context, dapperContext, configuration)
        {
        }

        public async Task<dynamic> GetBrandListData()
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 1);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Brand", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<dynamic> SaveBrandData(BrandVM data)
        {
            try
            {
                var parameters = new DynamicParameters();
                if (data.Id == null)
                {
                    var id = Guid.NewGuid();

                    parameters.Add("@Id", id); // Flag for insert
                    parameters.Add("@Flag", 2); // Flag for insert
                    parameters.Add("@TypeId", data.TypeId); // Flag for insert
                    parameters.Add("@DosageId", data.DosageId); // Flag for insert
                    parameters.Add("@Strength", data.Strength); // Flag for insert
                    parameters.Add("@PackageContainer", data.PackageContainer); // Flag for insert
                    parameters.Add("@PackageSize", data.PackageSize); // Flag for insert
                    parameters.Add("@Name", data.Name);
                    parameters.Add("@GenericId", data.GenericId);
                    parameters.Add("@ManufacturerId", data.ManufacturerId);
                }
                else
                {
                    parameters.Add("@Id", data.Id);
                    parameters.Add("@Flag", 3); // Flag for update
                    parameters.Add("@Name", data.Name);
                    parameters.Add("@GenericId", data.GenericId);
                    parameters.Add("@CompanyId", data.ManufacturerId);
                }

                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Brand", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex; // Consider logging the exception for better debugging
            }
        }

        public async Task<dynamic> DeleteBrandData(string id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 4);
                parameters.Add("@Id", id);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Brand", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<dynamic> SearchQuery(string querystring)
        {
            try
            {
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var sql = $@"
                   SELECT 
                    dm.Id,  
                    dd.Name + ' - ' + dm.Name + ' ( ' + dm.Strength + ' ) ' + ' - ' + dg.Name AS Name
                    FROM DrugMedicine dm
                    LEFT JOIN DrugDosage dd ON dm.DosageId = dd.Id
                    LEFT JOIN DrugGeneric dg ON dm.GenericId = dg.Id
                    LEFT JOIN DrugManufacturer c ON dm.ManufacturerId = c.Id
                    WHERE dm.Name LIKE '%{querystring}%';";
                    var query = await _dp.QueryAsync(sql);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<dynamic> GetDataById(string id)
        {
            try
            {
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var sql = $@"
                    SELECT 
  dm.Id,dm.Name,dg.Id as GenericId,dg.Name as GenericName,c.Id as ManufacturerId,c.Name as CompanyName, dm.PackageContainer, dm.PackageSize
  FROM DrugMedicine dm
  LEFT JOIN DrugGeneric dg ON dm.GenericId = dg.Id
  LEFT JOIN DrugManufacturer c ON dm.ManufacturerId = c.Id 
Where dm.Id ='{id}';";
                    var query = await _dp.QueryFirstOrDefaultAsync(sql);
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
