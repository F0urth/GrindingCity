using GrindingCity.Domain.Entities.Building;

namespace GrindingCity.Domain.Entities.District
{
    public sealed class DistrictEntity
    {
        public Guid Id { get; init; }
        public Guid CityId { get; init; }
        public string Name { get; init; } = default!;
        public int MaxBuildings { get; init; }
        public bool IsPossibleToCreateBuildings { get; set; }
        public IDictionary<BuildingEntity, Guid> Buildings { get; set; } = new Dictionary<BuildingEntity, Guid>();

        public DistrictEntity(
            Guid cityId,
            string name,
            int maxBuildings,
            bool isPossibleToCreateBuildings,
            IDictionary<BuildingEntity, Guid> buildings)
        {
            CityId = cityId;
            Name = name;
            MaxBuildings = maxBuildings;
            IsPossibleToCreateBuildings = isPossibleToCreateBuildings;
            Buildings = buildings;
        }
    }
}
