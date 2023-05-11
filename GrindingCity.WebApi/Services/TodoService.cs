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

        public async Task AddTodo(TodoDto dto)
        {
            var entity = new TodoEntity
            {
                Title = dto.Title,
                Status = dto.Status
            };

            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<TodoEntity>> GetAllTodos()
        {
            var todos = _dbContext.Todos.ToList();
            return todos;
        }
    }
}
