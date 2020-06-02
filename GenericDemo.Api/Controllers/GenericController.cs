namespace GenericDemo.Api.Controllers
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using AutoMapper;

    using GenericDemo.Domain.Models;
    using GenericDemo.Domain.Services.Abstract;
    using GenericDemo.Dto.Interface;

    using Microsoft.AspNetCore.Mvc;

    public class GenericController<TEntity, TDto, TCreate, TUpdate> : ControllerBase where TEntity : IEntity where TUpdate : IUpdateDto 
    {
        private readonly IRepository<TEntity> repository;

        private readonly IMapper mapper;

        private readonly ICreateService<TEntity, TCreate> createService;

        private readonly IUpdateService<TEntity, TUpdate> updateService;

        public GenericController(IRepository<TEntity> repository, IMapper mapper,ICreateService<TEntity, TCreate> createService, IUpdateService<TEntity, TUpdate> updateService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.createService = createService;
            this.updateService = updateService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(this.mapper.Map<TDto>(await this.repository.SingleOrDefault(x => x.Id == id)));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(TCreate dto)
        {
            var entity = await this.repository.Add(await this.createService.Create(dto));
            await this.repository.Commit();

            return Created($"{HttpContext.Request.Path}/{entity.Id}", this.mapper.Map<TDto>(entity));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(TUpdate dto)
        {
            var entity = await this.repository.SingleOrDefault(x => x.Id == dto.Id);

            entity = this.repository.Update(await this.updateService.Update(entity, dto));
            await this.repository.Commit();

            return Ok(this.mapper.Map<TDto>(entity));
        }
    }
}
