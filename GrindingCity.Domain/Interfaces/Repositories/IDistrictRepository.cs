using GrindingCity.Domain.Entities.District;

namespace GrindingCity.Domain.Interfaces.Repositories
{
    public interface IDistrictRepository
    {
        Task<DistrictEntity> CreateAsync(DistrictEntity district);
        Task<DistrictEntity> GetByIdAsync(Guid id);
    }
}
