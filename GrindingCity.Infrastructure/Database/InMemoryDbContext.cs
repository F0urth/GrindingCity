using GrindingCity.Domain.Entities.Building;
using GrindingCity.Domain.Entities.District;
using GrindingCity.Domain.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrindingCity.Infrastructure.Database
{
    public class InMemoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Building");
        }

        public DbSet<BuildingEntity> Buildings { get; set; }
        public DbSet<IResource> Resources { get; set; }
        public DbSet<DistrictEntity> Districts { get; set; }
    }
}