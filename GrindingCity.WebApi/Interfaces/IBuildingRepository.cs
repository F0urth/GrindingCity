using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Interfaces
{
    public interface IBuildingRepository
    {
        public Task<Building?> GetBuilding(Guid id);
        public Task<IEnumerable<Building>> GetAllBuildings();
        public Task AddBuilding(CreateBuildingRequest building);
        public Task UpdateBuilding(Guid id, UpdateBuildingRequest price);
        public Task DeleteBuilding(Guid id);
    }
}
