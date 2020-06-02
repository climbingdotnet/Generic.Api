namespace GenericDemo.Domain.Services.Abstract
{
    using System.Threading.Tasks;

    public interface IUpdateService<TEntity, TDto>
    {
        Task<TEntity> Update(TEntity entity, TDto dto);
    }
}
