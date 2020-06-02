namespace GenericDemo.Dto.Requests
{
    using GenericDemo.Dto.Interface;

    public class UpdateLikeDto : IUpdateDto
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
