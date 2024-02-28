using AuthenticationAuthorization.Authentication;
using AuthenticationAuthorization.Generics;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAuthorization.Repository
{
    public interface ICRUDRepository<T> where T: BaseEntity
    {
        public Task<List<T>> Get();
        public Task<T> Get(int id);
        public void Update(T entity);
        public void Insert(T entity);
        public void Delete(T entity);
    }

    public class CRUDRepository<T> : ICRUDRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> entities;

        public CRUDRepository(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();
        }
        
        public async Task<List<T>> Get()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(T entity)
        {
            if (entity is null)
                throw new NullReferenceException();

            entities.Update(entity);
            _dbContext.SaveChanges();
        }
        
        public void Insert(T entity)
        {
            if (entity is null)
                throw new NullReferenceException();

            entities.AddAsync(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity is null)
                throw new NullReferenceException();

            entities.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
