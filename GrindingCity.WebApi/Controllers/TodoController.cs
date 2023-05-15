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

        [HttpGet("status/{status}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<TodoEntity>))]
        public async Task<ActionResult<IEnumerable<TodoEntity>>> GetTodosByStatus(TodoStatus status)
        {
            var result = await _todoService.GetTodosByStatus(status);
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<TodoEntity>))]
        public async Task<ActionResult<TodoEntity>> GetTodoById(Guid id)
        {
            var result = await _todoService.GetTodoById(id);
            return new OkObjectResult(result);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(AddNewTodoDto))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, type: typeof(string))]
        public async Task<ActionResult> AddTodo(AddNewTodoDto todoDto)
        {
            await _todoService.AddTodo(todoDto);
            return new OkResult();
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(UpdateTodoStatusDto))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, type: typeof(string))]
        public async Task<ActionResult> UpdateTodo(UpdateTodoStatusDto dto)
        {
            await _todoService.UpdateTodo(dto);
            return new OkResult();
        }

        [HttpDelete]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, type: typeof(string))]
        public async Task<ActionResult> DeleteTodo(Guid id)
        {
            await _todoService.DeleteTodo(id);
            return new OkResult();
        }
    }
}
