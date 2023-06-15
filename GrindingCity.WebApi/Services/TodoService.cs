using GrindingCity.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GrindingCity.WebApi.Services;

public class TodoService : ITodoService
{
    private readonly TodoDbContext _dbContext;

    public TodoService(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TodoEntity>> GetAllTodosAsync()
    {
        return await _dbContext.Todos.ToListAsync();
    }

    public async Task<IEnumerable<TodoEntity>> GetTodosByStatusAsync(TodoStatus status)
    {
        return await _dbContext.Todos.Where(x => x.Status == status).ToListAsync();
    }

    public async Task<TodoEntity?> GetTodoByIdAsync(Guid id)
    {
        return await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);      
    }

    public async Task AddTodoAsync(AddNewTodoDto dto)
    {
        var entity = new TodoEntity
        {
            Title = dto.Title,
            Status = 0
        };

        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateTodoAsync(UpdateTodoStatusDto dto)
    {
        var todo = _dbContext.Todos.FirstOrDefault(x => x.Id == dto.Id);
        if (todo is not null)
        {
            todo.Status = dto.Status;
            _dbContext.Update(todo);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task CompleteTodoAsync(CompleteTodoDto dto)
    {
        var todo = _dbContext.Todos.FirstOrDefault(x => x.Id == dto.Id);
        if (todo is not null)
        {
            todo.Status = TodoStatus.Completed;
            _dbContext.Update(todo);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteTodoAsync(Guid id) 
    {
        var todo = _dbContext.Todos.FirstOrDefault(x => x.Id == id);
        if (todo is not null) 
        { 
            _dbContext.Todos.Remove(todo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
