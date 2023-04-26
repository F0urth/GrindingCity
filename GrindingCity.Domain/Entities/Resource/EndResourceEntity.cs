using GrindingCity.Domain.Entities.Resource.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrindingCity.Domain.Entities.Resource
{
    public sealed class EndResourceEntity : ResourceEntity
    {
        [NotMapped]
        public EndResourceNames EnumName { get; set; }

        public EndResourceEntity(Guid buildingId, EndResourceNames name)
        {
            BuildingId = buildingId;
            base.Name = name.ToString();
            EnumName = name;
        }

        public EndResourceEntity(Guid buildingId, EndResourceNames name, int amount) : this(buildingId, name)
        {
            Amount = amount;
        }
    }
}
