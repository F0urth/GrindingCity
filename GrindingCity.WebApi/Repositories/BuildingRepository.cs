using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using GrindingCity.WebApi.DTOs;

namespace GrindingCity.WebApi.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private AppDbContext _appDbContext;

        public BuildingRepository(AppDbContext db)
        {
            _appDbContext = db;
        }

        public async Task<Building?> GetBuildingAsync(Guid id) => await _appDbContext.Buildings.FirstOrDefaultAsync(b => b.Id == id);
        
        public async Task<IEnumerable<Building>> GetAllBuildingsAsync() => await _appDbContext.Buildings.ToListAsync();

        public async Task AddBuildingAsync(CreateBuildingRequest request)
        {
            var newBuiding = new Building()
            {
                Price = request.price,
                Type = request.buildingType
            };

             _appDbContext.Buildings.Add(newBuiding);
            await _appDbContext.SaveChangesAsync();
        }
        
        public async Task UpdateBuildingAsync(Guid id, UpdateBuildingRequest request)
        {
            var building = new Building()
            {
                Id = id,
                Price = request.price,
                Type = request.buildingType
            };

            _appDbContext.Update(building);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteBuildingAsync(Guid id)
        {
            var building = new Building() { Id = id };

            _appDbContext.Buildings.Remove(building);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
