using GrindingCity.WebApi.DTOs;
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
        public async Task<ActionResult<IEnumerable<Building>>> GetAllBuildings(
            [FromServices] IBuildingRepository handler)
        {
            var result = await handler.GetAllBuildings();

            return result is null ? NotFound() : Ok(result);
        }

        // GET api
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Building>> GetBuilding(Guid id,
            [FromServices] IBuildingRepository handler)
        {
            var result = await handler.GetBuilding(id);

            return result is null ? NotFound() : Ok(result);
        }

        // POST api
        [HttpPost]
        public async Task<ActionResult> AddBuilding([FromForm] CreateBuildingRequest building, 
            [FromServices] IBuildingRepository handler)
        {
            await handler.AddBuilding(building);
            return NoContent();
        }

        // PUT api
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateBuilding(Guid id, [FromBody] UpdateBuildingRequest building,
            [FromServices] IBuildingRepository handler)
        {
            await handler.UpdateBuilding(id, building);
            return NoContent();
        }

        // DELETE api
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoveBuilding(Guid id,
            [FromServices] IBuildingRepository handler)
        {
            await handler.DeleteBuilding(id);
            return NoContent();
        }
    }
}
