using GrindingCity.WebApi.Models;
using GrindingCity.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GrindingCity.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Todos")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<TodoEntity>))]
        public async Task<ActionResult<IEnumerable<TodoEntity>>> GetAllTodos()
        {
            var result = await _todoService.GetAllTodos();
            return new OkObjectResult(result);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(TodoDto))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, type: typeof(string))]
        public async Task<ActionResult> AddTodo(TodoDto todoDto)
        {
            await _todoService.AddTodo(todoDto);
            return new OkResult();
        }
    }
}
