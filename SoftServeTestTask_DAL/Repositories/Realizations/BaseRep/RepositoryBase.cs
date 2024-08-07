using Microsoft.EntityFrameworkCore;
using SoftServeTestTask_DAL.Database;
using SoftServeTestTask_DAL.Repositories.Interfaces.BaseRep;

namespace SoftServeTestTask_DAL.Repositories.Realizations.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly CoursesDbContext _db;

        public RepositoryBase(CoursesDbContext db)
        {
            _db = db;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var tmp = await _db.Set<T>().AddAsync(entity);
            return tmp.Entity;
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
