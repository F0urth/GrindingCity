using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Interfaces
{
    public interface IResourceRepository
    {
        public Task<Resource?> GetResourceAsync(Guid id);
        public Task<IEnumerable<Resource>> GetAllResourcesAsync();
        public Task AddResourceAsync(CreateResourceRequest building);
        public Task UpdateResourceAsync(Guid id, UpdateResourceRequest price);
        public Task DeleteResourceAsync(Guid id);
    }
}
