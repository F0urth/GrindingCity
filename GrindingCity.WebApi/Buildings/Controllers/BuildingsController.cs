using Domain.Buildings.Commands;
using Domain.Buildings.Queries;
using GrindingCity.WebApi.Buildings.Extensions;
using GrindingCity.WebApi.Buildings.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GrindingCity.WebApi.Buildings.Controllers;

[ApiController]
[Route("api/[controller]")]
[SwaggerTag("Buildings")]
public sealed class BuildingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BuildingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(ReadBuildingDto))]
    public async Task<ActionResult<ReadBuildingDto>> GetBuildingById(Guid id)
    {
        var query = new GetBuildingByIdQuery(id);
        var result = await _mediator.Send(query);
        if (result.IsFailure)
        {
            return UnprocessableEntity(result.Error);
        }
        
        return Ok(result.Value.ToReadDto());
    }
    
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<ReadBuildingDto>))]
    public async Task<ActionResult<IEnumerable<ReadBuildingDto>>> GetAllBuildings()
    {
        var query = new GetAllBuildingsQuery();
        var result = await _mediator.Send(query);

        return Ok(result.Select(e => e.ToReadDto()));
    }
    
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, type: typeof(ReadBuildingDto))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, type: typeof(string))]
    public async Task<ActionResult<ReadBuildingDto>> AddBuilding([FromBody]InputBuildingDto buildingDto)
    {
        var command = buildingDto.ToAddBuildingCommand();
        var result = await _mediator.Send(command);
        if (result.IsFailure)
        {
            return UnprocessableEntity(result.Error);
        }

        return CreatedAtAction(nameof(GetBuildingById), new {id = result.Value.Id}, result.Value.ToReadDto());
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoveById(Guid id)
    {
        var command = new RemoveBuildingByIdCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}