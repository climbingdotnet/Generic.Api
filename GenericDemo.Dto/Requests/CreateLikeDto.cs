namespace GenericDemo.Dto.Requests
{
    using System;

    public class CreateLikeDto
    {
        public Guid LanguageId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
