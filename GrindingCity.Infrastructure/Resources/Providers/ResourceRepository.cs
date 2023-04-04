using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Resources.Providers;
using GrindingCity.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace GrindingCity.Infrastructure.Resources.Providers;

public sealed class ResourceRepository : IResourceRepository
{
    private readonly GrindingCityDbContext _dbContext;

    public ResourceRepository(GrindingCityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<ResourceEntity>> GetAllBuildingsAsync()
    {
        return Task.FromResult(_dbContext.Resource.AsEnumerable());
    }

    public async Task<Maybe<ResourceEntity>> GetBuildingByAsync(Guid id)
    {
        var buildingEntity = await _dbContext.Resource.FindAsync(id);
        return Maybe.From(buildingEntity!);
    }

    public async Task<ResourceEntity> AddBuildingAsync(ResourceEntity entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task RemoveBuildingAsync(Guid id)
    {
        var buildingEntity = new ResourceEntity { Id = id };
        _dbContext.Entry(buildingEntity).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();
    }
}