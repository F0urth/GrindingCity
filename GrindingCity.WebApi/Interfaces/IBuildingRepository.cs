using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Interfaces
{
    public interface IBuildingRepository
    {
        public Task<Building?> GetBuildingAsync(Guid id);
        public Task<IEnumerable<Building>> GetAllBuildingsAsync();
        public Task AddBuildingAsync(CreateBuildingRequest building);
        public Task UpdateBuildingAsync(Guid id, UpdateBuildingRequest price);
        public Task DeleteBuildingAsync(Guid id);
    }
}
