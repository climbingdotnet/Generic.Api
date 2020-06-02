namespace GenericDemo.Domain.Services.Abstract
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> match, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> match);

        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> match, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> match);

        Task<TEntity> Add(TEntity t);

        TEntity Update(TEntity t);

        Task<bool> Any(Expression<Func<TEntity, bool>> match);

        Task Commit();

    }
}
