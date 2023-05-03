using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Exceptions;
using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Models;
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
            [FromServices] IBuildingRepository buildingHandler)
        {
            var buildings = await buildingHandler.GetAllBuildingsAsync();
            var result = new GetAllBuildingsResponse(buildings.Select(_ => _.Id));

            return result is null ? NotFound() : Ok(result);
        }

        // GET api
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Building>> GetBuilding(Guid id,
            [FromServices] IBuildingRepository buildingHandler,
            [FromServices] IResourceRepository resourceHandler)
        {
            var building = await buildingHandler.GetBuildingAsync(id) ?? throw new InvalidBuidingException();
            var resources = await resourceHandler.GetAllResourcesAsync();
            var result = new GetBuildingResponse(
                        building.Id, 
                        building.Price, 
                        building.Type, 
                        resources.Where(_ => _.BuildingId == building.Id));

            return Ok(result);
        }

        // POST api
        [HttpPost]
        public async Task<ActionResult> AddBuilding([FromForm] CreateBuildingRequest building, 
            [FromServices] IBuildingRepository buildingHandler)
        {
            await buildingHandler.AddBuildingAsync(building);
            return NoContent();
        }

        // PUT api
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateBuilding(Guid id, [FromBody] UpdateBuildingRequest building,
            [FromServices] IBuildingRepository buildingHandler)
        {
            await buildingHandler.UpdateBuildingAsync(id, building);
            return NoContent();
        }

        // DELETE api
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoveBuilding(Guid id,
            [FromServices] IBuildingRepository buildingHandler)
        {
            await buildingHandler.DeleteBuildingAsync(id);
            return NoContent();
        }
    }
}
