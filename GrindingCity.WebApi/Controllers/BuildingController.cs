﻿using GrindingCity.Core.Building.Commands.Create;
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
        public async Task<ActionResult<BuildingEntity>> CreateAsync([FromBody] CreateBuildingDto createBuildingDto)
        {
            var building = await _mediator.Send(new CreateBuildingCommand
            {
                DistrictId = createBuildingDto.districtId,
                Name = createBuildingDto.name,
                RawResource = createBuildingDto.rawResource,
                RawResourceAmount = createBuildingDto.rawResourceAmount,
                EndResource = createBuildingDto.endResource,
                EndResourceAmount = createBuildingDto.endResourceAmount
            });

            return Ok(building);
        }

        [HttpGet("{id}")]
        //statuscode
        public async Task<ActionResult<BuildingEntity>> Get(Guid id)
        {
            var building = await _mediator.Send(new GetByIdQuery(id));

            return Ok(building);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(Guid id, [FromBody] string name)
        {
            var result = await _mediator.Send(new UpdateBuildingCommand { Id = id, Name = name });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            await _mediator.Send(new DeleteBuildingCommand(id));

            return NoContent();
        }
    }
}
