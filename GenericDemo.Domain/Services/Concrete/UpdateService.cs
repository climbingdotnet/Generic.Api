namespace GenericDemo.Domain.Services.Concrete
{
    using System.Threading.Tasks;

    using AutoMapper;

    using FluentValidation;
    using FluentValidation.Results;

    using GenericDemo.Domain.Exceptions;
    using GenericDemo.Domain.Services.Abstract;

    public class UpdateService<TEntity, TDto> : IUpdateService<TEntity, TDto>
    {
        private readonly IValidator<TEntity> validator;

        private readonly IMapper mapper;

        public UpdateService(IValidator<TEntity> validator, IMapper mapper)
        {
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<TEntity> Update(TEntity entity, TDto dto)
        {
            this.mapper.Map(dto, entity);

            var validationResult = await this.validator.ValidateAsync(entity);

            this.ConsumeResult(validationResult);

            return entity;
        }

        private void ConsumeResult(ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                throw new EntityValidationException($"{nameof(TEntity)} failed validation", validationResult.Errors);
            }
        }
    }
}
