using CSharpFunctionalExtensions;
using Domain.Districts.Providers;
using Domain.Entities;
using GrindingCity.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace GrindingCity.Infrastructure.Districts.Providers
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly GrindingCityDbContext _dbContext;

        public DistrictRepository(GrindingCityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<DistrictEntity>> GetAllDistrictsAsync()
        {
            return Task.FromResult(_dbContext.District.AsEnumerable());
        }

        public async Task<Maybe<DistrictEntity>> GetDistrictByAsync(Guid id)
        {
            var districtEntity = await _dbContext.District.FindAsync(id);
            return Maybe.From(districtEntity!);
        }

        public async Task<DistrictEntity> AddDistrictAsync(DistrictEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task RemoveDistrictAsync(Guid id)
        {
            var districtEntity = new DistrictEntity { Id = id };
            _dbContext.Entry(districtEntity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
