namespace GenericDemo.Dto.Requests
{
    using System;

    using GenericDemo.Dto.Interface;

    public class UpdateLikeDto : IUpdateDto
    {
        public Guid LanguageId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
