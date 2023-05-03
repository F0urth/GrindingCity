using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Exceptions;
using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrindingCity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourseController : Controller
    {
        // GET all api
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Resourse>>> GetAllResourses(
            [FromServices] IResourseRepository resourseHandler)
        {
            var result = await resourseHandler.GetAllResoursesAsync();

            return result is null ? NotFound() : Ok(result);
        }

        // GET api
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Resourse>> GetResourse(Guid id,
            [FromServices] IResourseRepository resourseHandler)
        {
            var result = await resourseHandler.GetResourseAsync(id);

            return result is null ? NotFound() : Ok(result);
        }

        // POST api
        [HttpPost]
        public async Task<ActionResult> AddResourse([FromForm] CreateResourseRequest request,
            [FromServices] IResourseRepository resourseHandler,
            [FromServices] IBuildingRepository buildingHandler)
        {
            _ = await buildingHandler.GetBuildingAsync(request.buildingId) 
                ?? throw new InvalidBuidingException();

            await resourseHandler.AddResourseAsync(request);
            return NoContent();
        }

        // PUT api
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateResourse(Guid id, [FromBody] UpdateResourseRequest request,
            [FromServices] IResourseRepository resourseHandler,
            [FromServices] IBuildingRepository buildingHandler)
        {
            _ = await buildingHandler.GetBuildingAsync(request.buildingId)
                ?? throw new InvalidBuidingException();

            await resourseHandler.UpdateResourseAsync(id, request);
            return NoContent();
        }

        // DELETE api
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoveResourse(Guid id,
            [FromServices] IResourseRepository resourseHandler)
        {
            await resourseHandler.DeleteResourseAsync(id);
            return NoContent();
        }
    }
}
