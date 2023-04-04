using CSharpFunctionalExtensions;
using Domain.Entities;

namespace Domain.Resources.Providers;

public interface IResourceRepository
{
    Task<IEnumerable<ResourceEntity>> GetAllResourcesAsync();

    Task<Maybe<ResourceEntity>> GetResourceByAsync(Guid id);
    
    Task<ResourceEntity> AddResourceAsync(ResourceEntity entity);
    
    Task RemoveResourceAsync(Guid id);
}