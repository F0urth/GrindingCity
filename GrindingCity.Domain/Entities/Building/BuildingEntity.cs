using GrindingCity.Domain.Entities.Resource;

namespace GrindingCity.Domain.Entities.Building
{
    public class BuildingEntity
    {
        public Guid Id { get; init; }
        public Guid DistrictId { get; init; }
        public string Name { get; set; } = default!;
        public IList<ResourceEntity> Resources { get; set; } = default!;
    }
}