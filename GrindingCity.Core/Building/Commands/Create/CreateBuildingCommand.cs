using GrindingCity.Domain.Entities.Building;
using GrindingCity.Domain.Entities.Resource.Enums;
using MediatR;

namespace GrindingCity.Core.Building.Commands.Create
{
    public sealed class CreateBuildingCommand : IRequest<BuildingEntity>
    {
        public string Name { get; init; } = default!;
        public RawResourcesNames RawResource { get; init; }
        public int RawResourceAmount { get; init; }
        public EndResourceNames EndResource { get; init; }
        public int EndResourceAmount { get; init; }
    }
}
