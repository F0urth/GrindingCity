using CSharpFunctionalExtensions;
using Domain.Entities;

namespace Domain.Buildings.Providers;

public interface IBuildingRepository
{
    Task<IEnumerable<BuildingEntity>> GetAllBuildingsAsync();

    Task<Maybe<BuildingEntity>> GetBuildingByAsync(Guid id);
    
    Task<BuildingEntity> AddBuildingAsync(BuildingEntity entity);
    
    Task RemoveBuildingAsync(Guid id);
}