using GrindingCity.Domain.Entities.Resources.Enums;

namespace GrindingCity.Domain.Entities.Resources
{
    public sealed class RawResourceEntity : ResourceEntity
    {
        public RawResourcesNames Name { get; set; }

        public RawResourceEntity(int amount, RawResourcesNames name)
        {
            Amount = amount;
            Name = name;
        }
    }
}
