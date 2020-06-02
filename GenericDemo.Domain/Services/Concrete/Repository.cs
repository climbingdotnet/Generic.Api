namespace GenericDemo.Domain.Services.Concrete
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using GenericDemo.Domain.Context;
    using GenericDemo.Domain.Exceptions;
    using GenericDemo.Domain.Services.Abstract;

    using Microsoft.EntityFrameworkCore;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly GenericDemoContext context;
        public Repository(GenericDemoContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> match, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.Set(includes).Where(match);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> match)
        {
            return this.Where(match, null);
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> match, params Expression<Func<TEntity, object>>[] includes)
        {
            var entity = await this.Set(includes).FirstOrDefaultAsync(match);

            if (entity == null)
            {
                throw new EntityNotFoundException($"{nameof(TEntity)} not Found");
            }

            return entity;
        }

        public Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> match)
        {
            return this.SingleOrDefault(match, null);
        }

        public async Task<TEntity> Add(TEntity t)
        {
            var result = await this.context.AddAsync(t);

            return result.Entity;
        }

        public TEntity Update(TEntity t)
        {
            return this.context.Update(t).Entity;
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> match)
        {
            return await this.context.Set<TEntity>().AnyAsync(match);
        }

        public async Task Commit()
        {
            await this.context.SaveChangesAsync();
        }

        private IQueryable<TEntity> Set(params Expression<Func<TEntity, object>>[] includes)
        {
            var set = this.context.Set<TEntity>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    set = set.Include(include);
                }
            }

            return set;
        }
    }
}
