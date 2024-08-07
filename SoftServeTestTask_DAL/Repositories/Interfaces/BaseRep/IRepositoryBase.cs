
namespace SoftServeTestTask_DAL.Repositories.Interfaces.BaseRep
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
