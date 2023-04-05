using GrindingCity.Domain.Interfaces.Entities;

namespace GrindingCity.Domain.Entities.Resources
{
    public abstract class ResourceEntity : IResource
    {
        public Guid Id { get; init; }
        public int Amount { get; set; }
    }
}
