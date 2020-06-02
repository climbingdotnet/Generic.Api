namespace GenericDemo.Domain.Validators
{
    using FluentValidation;

    using GenericDemo.Domain.Models;

    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(50);
        }
    }
}
