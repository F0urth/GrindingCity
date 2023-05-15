using GrindingCity.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace GrindingCity.WebApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _dbContext;

        public TodoService(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TodoEntity>> GetAllTodos()
        {
            var todos = _dbContext.Todos.ToList();
            return todos;
        }

        public async Task<IEnumerable<TodoEntity>> GetTodosByStatus(TodoStatus status)
        {
            return _dbContext.Todos.Where(x => x.Status == status).ToList();
        }

        public async Task<TodoEntity> GetTodoById(Guid id)
        {
            return _dbContext.Todos.FirstOrDefault(x => x.Id == id);      
        }

        public Task AddTodo(AddNewTodoDto dto)
        {
            var entity = new TodoEntity
            {
                Title = dto.Title,
                Status = dto.Status
            };

            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task UpdateTodo(UpdateTodoStatusDto dto)
        {
            var todo = _dbContext.Todos.FirstOrDefault(x => x.Id == dto.Id);
            if (todo != null)
            {
                todo.Status = dto.Status;
                _dbContext.Update(todo);
            }
            return Task.CompletedTask;
        }

        public Task DeleteTodo(Guid id) 
        {
            var todo = _dbContext.Todos.FirstOrDefault(x => x.Id == id);
            if (todo != null) 
            { 
                _dbContext.Todos.Remove(todo); 
            }

            return Task.CompletedTask;
        }
    }
}
