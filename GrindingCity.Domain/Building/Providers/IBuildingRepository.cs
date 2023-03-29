namespace Domain.Building.Providers;

using Entities;

public interface IBuildingRepository
{
    Task<IEnumerable<BuildingEntity>> GetAllBuildingsAsync();

    Task<BuildingEntity> GetAllBuildingByAsync(Guid id);
    
    Task<BuildingEntity> AddBuildingAsync(BuildingEntity entity);
    
    Task RemoveBuildingAsync(Guid id);
}