using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Interfaces
{
    public interface IBuildingRepository
    {
        public Task<Building?> GetBuilding(Guid id);
        public Task<IEnumerable<Building>> GetAllBuildings();
        public Task AddBuiding(CreateBuildingRequest building);
        public Task UpdateBuiding(Guid id, CreateBuildingRequest price);
        public Task DeleteBuiding(Guid id);
    }
}
