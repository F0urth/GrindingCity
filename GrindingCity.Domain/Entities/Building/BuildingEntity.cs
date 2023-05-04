using GrindingCity.Domain.Interfaces.Entities;

namespace GrindingCity.Domain.Entities.Building
{
    public class BuildingEntity
    {
        public Guid Id { get; init; }
        public Guid DistrictId { get; init; }
        public string Name { get; set; } = default!;
        public IList<IResource> Resources { get; set; } = default!;
    }
}