using GrindingCity.Domain.Entities.Resources.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrindingCity.Domain.Entities.Resources
{
    public sealed class RawResourceEntity : ResourceEntity
    {
        [NotMapped]
        public RawResourcesNames EnumName { get; set; }

        public RawResourceEntity(Guid buildingId, RawResourcesNames name) 
        { 
            BuildingId = buildingId;
            base.Name = name.ToString();
            EnumName = name;
        }

        public RawResourceEntity(Guid buildingId, RawResourcesNames name, int amount) : this(buildingId, name)
        {
            Amount = amount;
        }
    }
}
