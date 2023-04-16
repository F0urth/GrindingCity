using GrindingCity.Domain.Interfaces.Entities;

namespace GrindingCity.Domain.Interfaces.Repositories
{
    public interface IResourcesRepository
    {
        public Task<IResource> AddAsync(IResource resource);
        public Task<IResource> GetByIdAsync(Guid resourceId);
        public Task<IEnumerable<IResource>> GetAllAsync(Guid buildingId);
        public Task<bool> ChangeAmountAsync(IResource resource);
        public Task<bool> RemoveAsync(Guid resourceId);
    }
}
