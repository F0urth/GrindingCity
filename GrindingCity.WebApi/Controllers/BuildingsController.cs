using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Models;
using GrindingCity.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrindingCity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        readonly IBuildingRepository _buildingRepository;
        public BuildingsController(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        // GET all api
        [HttpGet()]
        public ActionResult<Building> GetAllBuildings()
        {
            return Ok(_buildingRepository.GetAllBuildings());
        }

        // GET api
        [HttpGet("{id}")]
        public ActionResult<Building> GetBuilding(Guid id)
        {
            return Ok(_buildingRepository.GetBuilding(id));
        }

        // POST api
        [HttpPost]
        public ActionResult Post([FromForm] Building building)
        {
            _buildingRepository.AddBuiding(building);
            return Ok();
        }

        // PUT api
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] decimal price)
        {
            _buildingRepository.UpdateBuiding(id, price);
            return Ok();
        }

        // DELETE api
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _buildingRepository.DeleteBuiding(id);
            return Ok();
        }
    }
}
