using GrindingCity.Core.Interfaces.Infrastructure.Repositories;
using GrindingCity.Domain.Models;
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

        public async Task<Building> Post(Building building)
        {
            var result = _context.Buildings.Add(building);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Building> GetById(Guid id)
        {
            var result = await FindBuildingById(id);

            return result;
        }

        public async Task<bool> Update(Building building)
        {
            _context.Buildings.Update(building);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await FindBuildingById(id);

            if (result != null)
            {
                _context.Buildings.Remove(result);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        private async Task<Building> FindBuildingById(Guid id)
        {
            var result = await _context.Buildings.Where(x => x.Id == id).SingleOrDefaultAsync();

            return result;
        }
    }
}
