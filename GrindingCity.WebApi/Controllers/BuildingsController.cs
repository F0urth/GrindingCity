using Microsoft.AspNetCore.Mvc;

namespace GrindingCity.WebApi.Controllers;

using Models;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/[controller]")]
[SwaggerTag("Buildings")]
public sealed class BuildingsController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public ActionResult<BuildingDto> Get(Guid id)
    {
        return Ok();
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<BuildingDto>> Get()
    {
        return Ok();
    }
    
    [HttpPost]
    public ActionResult<BuildingDto> Post(Guid id)
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        return NoContent();
    }
}