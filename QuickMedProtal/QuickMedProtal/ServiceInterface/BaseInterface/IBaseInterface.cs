namespace QuickMedProtal.ServiceInterface.BaseInterface
{
    public interface IBaseInterface<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> FindByIdAsync(int id);
        Task<TEntity> FindByNoAsync(string no);
        Task<bool> InsertByAsync(TEntity entity);
        Task<bool> UpdateByAsync(TEntity entity);
    }
}
