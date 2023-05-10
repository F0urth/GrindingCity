using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Exceptions;
using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Models;
using GrindingCity.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrindingCity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        // GET all api
        [HttpGet()]
        public async Task<ActionResult<GetAllBuildingsResponse>> GetAllBuildings(
            [FromServices] IBuildingRepository buildingRepository)
        {
            var buildings = await buildingRepository.GetAllBuildingsAsync();
            var result = new GetAllBuildingsResponse(buildings.Select(building => building.Id));

            return result is null ? NotFound() : Ok(result);
        }

        // GET api
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Building>> GetBuilding(Guid id,
            [FromServices] IBuildingRepository buildingRepository,
            [FromServices] IResourceRepository resourceRepository)
        {
            var building = await buildingRepository.GetBuildingAsync(id) ?? throw new InvalidBuidingException();
            var resources = await resourceRepository.GetAllResourcesAsync();
            var result = new GetBuildingResponse(
                        building.Id, 
                        building.Price, 
                        building.Type, 
                        resources.Where(resource => resource.BuildingId == building.Id));

            return Ok(result);
        }

        // POST api
        [HttpPost]
        public async Task<ActionResult> AddBuilding([FromForm] CreateBuildingRequest building, 
            [FromServices] IBuildingRepository buildingRepository)
        {
            await buildingRepository.AddBuildingAsync(building);
            return NoContent();
        }

        // PUT api
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateBuilding(Guid id, [FromBody] UpdateBuildingRequest building,
            [FromServices] IBuildingRepository buildinRepository)
        {
            await buildingRepository.UpdateBuildingAsync(id, building);
            return NoContent();
        }

        // DELETE api
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoveBuilding(Guid id,
            [FromServices] IBuildingRepository buildingRepository)
        {
            await buildingRepository.DeleteBuildingAsync(id);
            return NoContent();
        }
    }
}
