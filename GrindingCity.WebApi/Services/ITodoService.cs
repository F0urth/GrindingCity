using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Services;

public interface ITodoService
{
    Task AddTodo(TodoDto dto);
    Task<IEnumerable<TodoEntity>> GetAllTodos();
}