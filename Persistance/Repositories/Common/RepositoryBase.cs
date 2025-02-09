using Domain.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistance.Repositories.Common
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext DataContext { get; set; }

        protected RepositoryBase(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IQueryable<T> FindAll(bool trackChanges = false) =>
            !trackChanges ?
                DataContext.Set<T>().AsNoTracking() :
                DataContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
            !trackChanges ?
                DataContext.Set<T>().Where(expression).AsNoTracking() :
                DataContext.Set<T>().Where(expression);

        public void Create(T entity) => DataContext.Set<T>().Add(entity);

        public void Update(T entity) => DataContext.Set<T>().Update(entity);

        public void Delete(T entity) => DataContext.Set<T>().Remove(entity);
    }
}