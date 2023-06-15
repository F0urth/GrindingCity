using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Services;

public interface ITodoService
{  
    Task<IEnumerable<TodoEntity>> GetAllTodosAsync();
    Task<IEnumerable<TodoEntity>> GetTodosByStatusAsync(TodoStatus status);
    Task<TodoEntity> GetTodoByIdAsync(Guid id);
    Task AddTodoAsync(AddNewTodoDto dto);
    Task UpdateTodoAsync(UpdateTodoStatusDto dto);
    Task CompleteTodoAsync(CompleteTodoDto dto);
    Task DeleteTodoAsync(Guid id);
}