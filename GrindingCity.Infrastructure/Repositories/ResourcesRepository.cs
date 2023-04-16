using GrindingCity.Domain.Interfaces.Entities;
using GrindingCity.Domain.Interfaces.Repositories;
using GrindingCity.Infrastructure.Database;

namespace GrindingCity.Infrastructure.Repositories
{
    public class ResourcesRepository : IResourcesRepository
    {
        private readonly InMemoryDbContext _context;

        public ResourcesRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<IResource> AddAsync(IResource resource)
        {
            var result = _context.Resources.Add(resource);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IResource> GetByIdAsync(Guid resourceId)
        {
            var result = await _context.Resources.FindAsync(resourceId);

            return result!;
        }

        public Task<IEnumerable<IResource>> GetAllAsync(Guid buildingId)
        {
            var result = Task.FromResult(_context.Resources.AsEnumerable());

            return result;
        }

        public async Task<bool> ChangeAmountAsync(IResource resource)
        {
            _context.Resources.Update(resource);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveAsync(Guid resourceId)
        {
            var result = _context.Resources.FindAsync(resourceId);

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
