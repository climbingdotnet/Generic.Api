namespace GenericDemo.Api.Controllers
{
    using AutoMapper;

    using GenericDemo.Domain.Models;
    using GenericDemo.Domain.Services.Abstract;
    using GenericDemo.Dto;
    using GenericDemo.Dto.Requests;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class LikeController : GenericController<Like, LikeDto, CreateLikeDto, UpdateLikeDto>
    {
        public LikeController(IRepository<Like> repository, IMapper mapper, ICreateService<Like, CreateLikeDto> createService, IUpdateService<Like, UpdateLikeDto> updateService)
            : base(repository, mapper, createService, updateService)
        {
        }
    }
}
