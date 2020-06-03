namespace GenericDemo.Domain.Validators
{
    using FluentValidation;

    using GenericDemo.Domain.Models;

    public class LikeValidator : AbstractValidator<Like>
    {
        public LikeValidator()
        {
            RuleSet("update", () => { RuleFor(e => e.Id).NotEmpty(); });

            RuleFor(e => e.Email).NotEmpty();
            RuleFor(e => e.LanguageId).NotEmpty();
            RuleFor(e => e.Name).NotEmpty();
        }
    }
}
