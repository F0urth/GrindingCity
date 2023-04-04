using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GrindingCity.WebApi.Resources.Controllers;

[ApiController]
[Route("api/[controller]")]
[SwaggerTag("Resources")]
public class ResourcesController : ControllerBase
{
    
}