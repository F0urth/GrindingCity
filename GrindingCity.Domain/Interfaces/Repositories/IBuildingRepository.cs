using GrindingCity.Domain.Entities.Building;

namespace GrindingCity.Domain.Interfaces.Repositories
{
    public interface IBuildingRepository
    {
        public Task<BuildingEntity> CreateAsync(BuildingEntity building);
        public Task<BuildingEntity> GetByIdAsync(Guid id);
        public Task<bool> UpdateAsync(BuildingEntity building);
        public Task<bool> DeleteAsync(Guid id);
    }
}
