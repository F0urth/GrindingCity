using GrindingCity.Domain.Models;
using GrindingCity.WebApi.DTO.Commands.BuildingCommands.Create;
using GrindingCity.WebApi.DTO.Commands.BuildingCommands.Delete;
using GrindingCity.WebApi.DTO.Commands.BuildingCommands.Update;
using GrindingCity.WebApi.DTO.Queries.BuildingQueries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrindingCity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Building> Post([FromBody] string name)
        {
            var building = await _mediator.Send(new CreateCommand(name));

            return building;
        }

        [HttpGet("{id}")]
        public async Task<Building> Get(Guid id)
        {
            var building = await _mediator.Send(new GetByIdQuery { Id = id });

            return building;
        }

        [HttpPut("{id}")]
        public async Task<bool> Put(Guid id, [FromBody] string name)
        {
            var result = await _mediator.Send(new UpdateCommand(id, name));

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCommand { Id = id });

            return result;
        }
    }
}
