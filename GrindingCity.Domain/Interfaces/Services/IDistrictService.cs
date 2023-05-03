using GrindingCity.Domain.Entities.District;

namespace GrindingCity.Domain.Interfaces.Services
{
    public interface IDistrictService
    {
        void CreateDistrict(Random random, Guid cityId, string name);
        Task<DistrictEntity> GetByIdAsync(Guid id);
        void DisableIsPossibleToCreateBuildings(DistrictEntity district);
    }
}
