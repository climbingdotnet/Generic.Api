namespace GenericDemo.Api.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using AutoMapper;

    using GenericDemo.Domain.Models;
    using GenericDemo.Domain.Services.Abstract;
    using GenericDemo.Dto;
    using GenericDemo.Dto.Requests;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class LanguagesController : GenericController<Language, LanguageDto, CreateLanguageDto, UpdateLanguageDto>
    {
        private readonly IRepository<Language> repository;

        private readonly IMapper mapper;

        public LanguagesController(IRepository<Language> repository, IMapper mapper, ICreateService<Language, CreateLanguageDto> createService, IUpdateService<Language, UpdateLanguageDto> updateService)
            : base(repository, mapper, createService, updateService)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this.mapper.Map<IEnumerable<LanguageDto>>(this.repository.Where(x => true)));
        }
    }
}
