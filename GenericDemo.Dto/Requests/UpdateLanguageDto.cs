namespace GenericDemo.Dto.Requests
{
    using GenericDemo.Dto.Interface;

    public class UpdateLanguageDto : IUpdateDto
    {
        public string Name { get; set; }
    }
}
