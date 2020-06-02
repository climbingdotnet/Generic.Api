namespace GenericDemo.Domain.Services.Abstract
{
    using System.Threading.Tasks;

    public interface ICreateService<TEntity, TDto>
    {
        Task<TEntity> Create(TDto dto);
    }
}
