using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Exceptions;
using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Translations;
using Microsoft.AspNetCore.Mvc;

namespace GrindingCity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : Controller
    {
        // GET all api
        [HttpGet()]
        public async Task<ActionResult<GetAllResourcesResponse>> GetAllResources(
            [FromServices] IResourceRepository resourceRepository)
        {
            var result = await resourceRepository.GetAllResourcesAsync();

            return Ok(result);
        }

        // GET api
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetResourcesResponse>> GetResource(Guid id,
            [FromServices] IResourceRepository resourceRepository)
        {
            var resource = await resourceRepository.GetResourceAsync(id);

            if (resource is null) return NotFound();

            var mappedResourse = resource.Map;

            return Ok(mappedResourse);
        }

        // POST api
        [HttpPost]
        public async Task<ActionResult> AddResource([FromForm] CreateResourceRequest request,
            [FromServices] IResourceRepository resourceRepository,
            [FromServices] IBuildingRepository buildingRepository)
        {
            var building = await buildingRepository.GetBuildingAsync(request.buildingId);

            if (building is null) return NotFound();

            await resourceRepository.AddResourceAsync(request);
            return NoContent();
        }

        // PUT api
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateResource(Guid id, [FromBody] UpdateResourceRequest request,
            [FromServices] IResourceRepository resourceRepository,
            [FromServices] IBuildingRepository buildingRepository)
        {
            var building = await buildingRepository.GetBuildingAsync(request.buildingId);

            if(building is null) return NotFound();

            await resourceRepository.UpdateResourceAsync(id, request);
            return Ok();
        }

        // DELETE api
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoveResource(Guid id,
            [FromServices] IResourceRepository resourceRepository)
        {
            await resourceRepository.DeleteResourceAsync(id);
            return Ok();
        }
    }
}
