using GrindingCity.Domain.Entities.Resource.Enums;
using MediatR;

namespace GrindingCity.Core.Resource.Commands.Create
{
    public sealed class CreateResourceCommand : IRequest
    {
        public Guid BuildingId { get; set; }
        public ResourceType ResourceType { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; } = 0;
    }
}
