using Domain.Districts.Commands;
using Domain.Districts.Queries;
using GrindingCity.WebApi.Districts.Extensions;
using GrindingCity.WebApi.Districts.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GrindingCity.WebApi.Districts.Controllers;

[ApiController]
[Route("api/[controller]")]
[SwaggerTag("Districts")]
public class DistrictsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DistrictsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(ReadDistrictDto))]
    public async Task<ActionResult<ReadDistrictDto>> GetDistrictById(Guid id)
    {
        var query = new GetDistrictByIdQuery(id);
        var result = await _mediator.Send(query);
        if (result.IsFailure)
        {
            return UnprocessableEntity(result.Error);
        }

        return Ok(result.Value.ToReadDto());
    }

    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<ReadDistrictDto>))]
    public async Task<ActionResult<IEnumerable<ReadDistrictDto>>> GetAllRDistricts()
    {
        var query = new GetAllDistrictsQuery();
        var result = await _mediator.Send(query);

        return Ok(result.Select(e => e.ToReadDto()));
    }

    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, type: typeof(ReadDistrictDto))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, type: typeof(string))]
    public async Task<ActionResult<ReadDistrictDto>> AddResource([FromBody] InputDistrictDto resourceDto)
    {
        var command = resourceDto.ToAddDistrictCommand();
        var result = await _mediator.Send(command);
        if (result.IsFailure)
        {
            return UnprocessableEntity(result.Error);
        }

        return CreatedAtAction(nameof(GetDistrictById), new { id = result.Value.Id }, result.Value.ToReadDto());
    }


    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoveById(Guid id)
    {
        var command = new RemoveDistrictByIdCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
