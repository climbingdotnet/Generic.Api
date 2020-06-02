namespace GenericDemo.Domain.Exceptions
{
    using System.Collections.Generic;

    using FluentValidation;
    using FluentValidation.Results;

    public sealed class EntityValidationException : ValidationException
    {
        public EntityValidationException(string message, IEnumerable<ValidationFailure> errors)
            : base(message, errors)
        {
        }
    }
}
