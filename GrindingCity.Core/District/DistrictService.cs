using GrindingCity.Domain.Entities.Building;
using GrindingCity.Domain.Entities.District;
using GrindingCity.Domain.Interfaces.Repositories;
using GrindingCity.Domain.Interfaces.Services;

namespace GrindingCity.Core.District
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public async void CreateDistrict(Random random, Guid cityId, string name)
        {
            var buldings = new Dictionary<BuildingEntity, Guid>();
            var maxBuildings = random.Next(1, 100);

            var district = new DistrictEntity(cityId, name, maxBuildings, true, buldings);

            await _districtRepository.CreateAsync(district);
        }

        public async Task<DistrictEntity> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            var result = await _districtRepository.GetByIdAsync(id);

            return result;
        }

        public void DisableIsPossibleToCreateBuildings(DistrictEntity district)
        {
            district.IsPossibleToCreateBuildings = false;
        }
    }
}
