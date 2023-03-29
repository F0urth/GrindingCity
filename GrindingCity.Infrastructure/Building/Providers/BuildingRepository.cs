namespace GrindingCity.Infrastructure.Building.Providers;

using CSharpFunctionalExtensions;
using Domain.Building.Providers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

public sealed class BuildingRepository : IBuildingRepository
{
    private readonly GrindingCityDbContext _dbContext;

    public BuildingRepository(GrindingCityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<BuildingEntity>> GetAllBuildingsAsync()
    {
        return Task.FromResult(_dbContext.Building.AsEnumerable());
    }

    public async Task<Maybe<BuildingEntity>> GetBuildingByAsync(Guid id)
    {
        var buildingEntity = await _dbContext.Building.FindAsync(id);
        return Maybe.From(buildingEntity!);
    }

    public async Task<BuildingEntity> AddBuildingAsync(BuildingEntity entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task RemoveBuildingAsync(Guid id)
    {
        var buildingEntity = new BuildingEntity { Id = id };
        _dbContext.Entry(buildingEntity).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();
    }
}