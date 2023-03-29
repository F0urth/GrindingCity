using GrindingCity.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GrindingCity.Infrastructure.Database
{
    public class InMemoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Building");
        }

        public DbSet<Building> Buildings { get; set; }
    }
}