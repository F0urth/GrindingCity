using GrindingCity.Core.Building.Commands.Create;
using GrindingCity.Core.Building.Commands.Delete;
using GrindingCity.Core.Building.Commands.Update;
using GrindingCity.Core.Building.Queries.GetById;
using GrindingCity.Domain.Entities.Building;
using GrindingCity.WebApi.DTO.Building;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BuildingEntity>> CreateAsync([FromBody] CreateBuildingDto createBuildingDto)
        {
            var building = await _mediator.Send(new CreateBuildingCommand
            {
                DistrictId = createBuildingDto.districtId,
                Name = createBuildingDto.name,
                RawResource = createBuildingDto.rawResourceName,
                RawResourceAmount = createBuildingDto.rawResourceAmount,
                EndResource = createBuildingDto.endResourceName,
                EndResourceAmount = createBuildingDto.endResourceAmount
            });

            return Ok(building);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<BuildingEntity>> GetAsync(Guid id)
        {
            var building = await _mediator.Send(new GetByIdQuery(id));

            return Ok(building);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> UpdateAsync([FromBody] UpdateBuildingDto updateBuildingDto)
        {
            var result = await _mediator.Send(new UpdateBuildingCommand
            {
                Id = updateBuildingDto.id,
                Name = updateBuildingDto.name,
                RawResourceName = updateBuildingDto.rawResourceName,
                RawResourceAmount = updateBuildingDto.rawResourceAmount,
                EndResourceName = updateBuildingDto.endResourceName,
                EndResourceAmount = updateBuildingDto.endResourceAmount
            });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            await _mediator.Send(new DeleteBuildingCommand(id));

            return NoContent();
        }
    }
}
