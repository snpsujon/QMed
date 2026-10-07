using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.ServiceInterface.BaseInterface;

namespace QuickMedProtal.ServiceRepository.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseInterface<TEntity> where TEntity : class
    {
        protected readonly EFContext _context;
        protected readonly DapperContext _dapperContext;
        protected readonly IConfiguration _configuration;
        public BaseRepository(EFContext context, DapperContext dapperContext,IConfiguration configuration)
        {
            _context = context;
            _dapperContext = dapperContext;
            _configuration = configuration;
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            try
            {
                //var response = await httpClient.GetAsync($"{api}/{id}");
                //if (response.IsSuccessStatusCode)
                //{
                //    var responceContent = await response.Content.ReadAsStringAsync();
                //    var client = System.Text.Json.JsonSerializer.Deserialize<TEntity>(responceContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                //    return client;
                //}
                //else
                //{
                //    return null;
                //}
                return _context.Set<TEntity>().Find(id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<TEntity> FindByNoAsync(string no)
        {
            try
            {
                var data = _context.Set<TEntity>().Find(no);


                return data;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                var data = await _context.Set<TEntity>().ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertByAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                var result = await SaveChanges() > 0;
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateByAsync(TEntity entity)
        {
            try
            {
                var result = _context.Set<TEntity>().Attach(entity);
                result.State = EntityState.Modified;
                var isExecuted = await SaveChanges() > 0;
                return isExecuted;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
