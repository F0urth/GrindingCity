using Domain.Districts.Queries;
using Domain.Resources.Queries;
using GrindingCity.WebApi.Districts.Extensions;
using GrindingCity.WebApi.Districts.Models;
using GrindingCity.WebApi.Resources.Models;
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
    public async Task<ActionResult<IEnumerable<ReadResourceDto>>> GetAllRDistricts()
    {
        var query = new GetAllDistrictsQuery();
        var result = await _mediator.Send(query);

        return Ok(result.Select(e => e.ToReadDto()));
    }
}
