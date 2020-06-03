namespace GenericDemo.Domain.Services.Concrete
{
    using System.Threading.Tasks;

    using AutoMapper;

    using FluentValidation;
    using FluentValidation.Results;

    using GenericDemo.Domain.Exceptions;
    using GenericDemo.Domain.Services.Abstract;

    public class CreateService<TEntity, TDto> : ICreateService<TEntity, TDto>
    {
        private readonly IValidator<TEntity> validator;

        private readonly IMapper mapper;

        public CreateService(IValidator<TEntity> validator, IMapper mapper)
        {
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<TEntity> Create(TDto dto)
        {
            var entity = this.mapper.Map<TEntity>(dto);

            var validationResult = await this.validator.ValidateAsync(entity, ruleSet: "default,create");

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
