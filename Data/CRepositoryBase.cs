using DisasterResponseHub.ResourceAccess;
using System.Linq.Expressions;

namespace DisasterResponseHub.Data
{
    public class CRepositoryBase<T> where T : class
    {
        protected AppDbContext _appDbContext { get; set; }
        public CRepositoryBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _appDbContext.Set<T>().Where(expression);
        }

        public IQueryable<T> FindAll()
        {
            return _appDbContext.Set<T>();
        }

        public T FindById(int id)
        {
            return _appDbContext!.Set<T>().Find(id);
        }
    }
}
