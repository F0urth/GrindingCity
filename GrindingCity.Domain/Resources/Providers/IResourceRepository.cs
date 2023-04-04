using CSharpFunctionalExtensions;
using Domain.Entities;

namespace Domain.Resources.Providers;

public interface IResourceRepository
{
    Task<IEnumerable<ResourceEntity>> GetAllBuildingsAsync();

    Task<Maybe<ResourceEntity>> GetBuildingByAsync(Guid id);
    
    Task<ResourceEntity> AddBuildingAsync(ResourceEntity entity);
    
    Task RemoveBuildingAsync(Guid id);
}