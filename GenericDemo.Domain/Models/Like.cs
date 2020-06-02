namespace GenericDemo.Domain.Models
{
    using System;

    public class Like : IEntity
    {
        public Guid LanguageId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual Language Language { get; set; }
    }
}
