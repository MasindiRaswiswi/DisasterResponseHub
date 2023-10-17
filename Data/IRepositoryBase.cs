using System.Linq.Expressions;

namespace DisasterResponseHub.Data
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAll();
        T FindById(int id);
    }
}
