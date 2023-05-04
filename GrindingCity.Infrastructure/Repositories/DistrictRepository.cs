using GrindingCity.Domain.Entities.District;
using GrindingCity.Domain.Interfaces.Repositories;
using GrindingCity.Infrastructure.Database;

namespace GrindingCity.Infrastructure.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly InMemoryDbContext _context;

        public DistrictRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<DistrictEntity> CreateAsync(DistrictEntity district)
        {
            var result = _context.Districts.Add(district);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<DistrictEntity> GetByIdAsync(Guid id)
        {
            var result = await _context.Districts.FindAsync(id);

            return result!;
        }
    }
}
