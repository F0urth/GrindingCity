using GrindingCity.Domain.Entities.Building;
using GrindingCity.Domain.Interfaces.Repositories;
using GrindingCity.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GrindingCity.Infrastructure.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly InMemoryDbContext _context;

        public BuildingRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<BuildingEntity> CreateAsync(BuildingEntity building)
        {
            var result = _context.Buildings.Add(building);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<BuildingEntity> GetByIdAsync(Guid id)
        {
            var result = await _context.Buildings.FindAsync(id);

            return result!;
        }

        public async Task<bool> UpdateAsync(BuildingEntity building)
        {
            _context.Buildings.Update(building);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = new BuildingEntity { Id = id };

            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
