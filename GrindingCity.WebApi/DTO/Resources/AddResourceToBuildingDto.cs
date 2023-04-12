using GrindingCity.Domain.Entities.Resource.Enums;

namespace GrindingCity.WebApi.DTO.Resources
{
    public class AddResourceToBuildingDto
    {
        public Guid BuildingId { get; set; }
        public ResourceType ResourceType { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
