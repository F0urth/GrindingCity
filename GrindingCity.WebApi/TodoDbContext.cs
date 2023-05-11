using GrindingCity.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GrindingCity.WebApi
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoEntity> Todos { get; set; }

        public TodoDbContext(DbContextOptions options) : base(options) { }
    }
}
