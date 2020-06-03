namespace GenericDemo.Dto
{
    using System;

    public class LikeDto
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
