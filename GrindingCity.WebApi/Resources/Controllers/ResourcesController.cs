using Domain.Resources.Commands;
using Domain.Resources.Queries;
using GrindingCity.WebApi.Resources.Extensions;
using GrindingCity.WebApi.Resources.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GrindingCity.WebApi.Resources.Controllers;

[ApiController]
[Route("api/[controller]")]
[SwaggerTag("Resources")]
public class ResourcesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResourcesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(ReadResourceDto))]
    public async Task<ActionResult<ReadResourceDto>> GetResourceById(Guid id)
    {
        var query = new GetResourceByIdQuery(id);
        var result = await _mediator.Send(query);
        if (result.IsFailure)
        {
            return UnprocessableEntity(result.Error);
        }
        
        return Ok(result.Value.ToReadDto());
    }
    
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<ReadResourceDto>))]
    public async Task<ActionResult<IEnumerable<ReadResourceDto>>> GetAllResources()
    {
        var query = new GetAllResourcesQuery();
        var result = await _mediator.Send(query);

        return Ok(result.Select(e => e.ToReadDto()));
    }
    
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, type: typeof(ReadResourceDto))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, type: typeof(string))]
    public async Task<ActionResult<ReadResourceDto>> AddResource([FromBody]InputResourceDto resourceDto)
    {
        var command = resourceDto.ToAddResourceCommand();
        var result = await _mediator.Send(command);
        if (result.IsFailure)
        {
            return UnprocessableEntity(result.Error);
        }

        return CreatedAtAction(nameof(GetResourceById), new { id = result.Value.Id }, result.Value.ToReadDto());
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoveById(Guid id)
    {
        var command = new RemoveResourceByIdCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}