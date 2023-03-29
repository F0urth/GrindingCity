namespace Domain.Building.Providers;

using CSharpFunctionalExtensions;
using Entities;

public interface IBuildingRepository
{
    Task<IEnumerable<BuildingEntity>> GetAllBuildingsAsync();

    Task<Maybe<BuildingEntity>> GetBuildingByAsync(Guid id);
    
    Task<BuildingEntity> AddBuildingAsync(BuildingEntity entity);
    
    Task RemoveBuildingAsync(Guid id);
}