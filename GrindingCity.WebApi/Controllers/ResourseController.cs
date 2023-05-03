using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Exceptions;
using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrindingCity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : Controller
    {
        // GET all api
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Resource>>> GetAllResources(
            [FromServices] IResourceRepository resourceHandler)
        {
            var result = await resourceHandler.GetAllResourcesAsync();

            return result is null ? NotFound() : Ok(result);
        }

        // GET api
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Resource>> GetResource(Guid id,
            [FromServices] IResourceRepository resourceHandler)
        {
            var result = await resourceHandler.GetResourceAsync(id);

            return result is null ? NotFound() : Ok(result);
        }

        // POST api
        [HttpPost]
        public async Task<ActionResult> AddResource([FromForm] CreateResourceRequest request,
            [FromServices] IResourceRepository resourceHandler,
            [FromServices] IBuildingRepository buildingHandler)
        {
            _ = await buildingHandler.GetBuildingAsync(request.buildingId) 
                ?? throw new InvalidBuidingException();

            await resourceHandler.AddResourceAsync(request);
            return NoContent();
        }

        // PUT api
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateResource(Guid id, [FromBody] UpdateResourceRequest request,
            [FromServices] IResourceRepository resourceHandler,
            [FromServices] IBuildingRepository buildingHandler)
        {
            _ = await buildingHandler.GetBuildingAsync(request.buildingId)
                ?? throw new InvalidBuidingException();

            await resourceHandler.UpdateResourceAsync(id, request);
            return NoContent();
        }

        // DELETE api
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoveResource(Guid id,
            [FromServices] IResourceRepository resourceHandler)
        {
            await resourceHandler.DeleteResourceAsync(id);
            return NoContent();
        }
    }
}
