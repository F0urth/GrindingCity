using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GrindingCity.WebApi.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private AppDbContext _appDbContext;

        public ResourceRepository(AppDbContext db) 
        {
            _appDbContext = db;
        }

        public async Task<Resource?> GetResourceAsync(Guid id) => await _appDbContext.Resources.FirstOrDefaultAsync(b => b.Id == id);

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync() 
        {
            return await _appDbContext.Resources.ToListAsync();
        }

        public async Task AddResourceAsync(CreateResourceRequest request)
        {
            var newResource = new Resource()
            {
                Title = request.title,
                Price = request.price,
                BuildingId = request.buildingId
            };

            _appDbContext.Resources.Add(newResource);

            await _appDbContext.SaveChangesAsync();
        }
        
        public async Task UpdateResourceAsync(Guid id, UpdateResourceRequest request)
        {
            var resource = new Resource()
            {
                Id = id,
                Title = request.title,
                Price = request.price,
                BuildingId = request.buildingId
            };

            _appDbContext.Update(resource);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteResourceAsync(Guid id)
        {
            var resource = new Resource() { Id = id };

            _appDbContext.Resources.Remove(resource);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
