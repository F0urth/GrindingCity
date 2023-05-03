using GrindingCity.WebApi.DTOs;
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
            [FromServices] IResourseRepository handler)
        {
            var result = await handler.GetAllResourses();

            return result is null ? NotFound() : Ok(result);
        }

        // GET api
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Resourse>> GetResourse(Guid id,
            [FromServices] IResourseRepository handler)
        {
            var result = await handler.GetResourse(id);

            return result is null ? NotFound() : Ok(result);
        }

        // POST api
        [HttpPost]
        public async Task<ActionResult> AddResourse([FromForm] CreateResourseRequest resourse,
            [FromServices] IResourseRepository handler)
        {
            await handler.AddResourse(resourse);
            return NoContent();
        }

        // PUT api
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateResourse(Guid id, [FromBody] UpdateResourseRequest resourse,
            [FromServices] IResourseRepository handler)
        {
            await handler.UpdateResourse(id, resourse);
            return NoContent();
        }

        // DELETE api
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoveResourse(Guid id,
            [FromServices] IResourseRepository handler)
        {
            await handler.DeleteResourse(id);
            return NoContent();
        }
    }
}
