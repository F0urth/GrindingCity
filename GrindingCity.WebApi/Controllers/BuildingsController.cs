using Microsoft.AspNetCore.Mvc;

namespace GrindingCity.WebApi.Controllers;

using Domain.Building.Query;
using Extensions;
using MediatR;
using Models;
using Swashbuckle.AspNetCore.Annotations;

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
    public async Task<ActionResult<BuildingDto>> GetBuildingById(Guid id)
    {
        var query = new GetBuildingByIdQuery(id);
        var result = await _mediator.Send(query);
        if (result.IsFailure)
        {
            return UnprocessableEntity(result.Error);
        }
        
        return Ok(result.Value.ToDto());
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BuildingDto>>> GetAllBuildings()
    {
        var query = new GetAllBuildingsQuery();
        var result = await _mediator.Send(query);

        return Ok(result.Select(e => e.ToDto()));
    }
    
    [HttpPost]
    public async Task<ActionResult<BuildingDto>> AddBuilding([FromBody]BuildingDto buildingDto)
    {
        var command = buildingDto.ToAddBuildingCommand();
        var result = await _mediator.Send(command);
        if (result.IsFailure)
        {
            return UnprocessableEntity(result.Error);
        }
        
        return Ok(result.Value);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult RemoveById(Guid id)
    {
        return NoContent();
    }
}