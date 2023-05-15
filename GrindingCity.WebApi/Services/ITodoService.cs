using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Services;

public interface ITodoService
{  
    Task<IEnumerable<TodoEntity>> GetAllTodos();
    Task<IEnumerable<TodoEntity>> GetTodosByStatus(TodoStatus status);
    Task<TodoEntity> GetTodoById(Guid id);
    Task AddTodo(AddNewTodoDto dto);
    Task UpdateTodo(UpdateTodoStatusDto dto);
    Task DeleteTodo(Guid id);
}