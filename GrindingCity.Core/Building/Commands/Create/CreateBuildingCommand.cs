using GrindingCity.Domain.Entities.Building;
using GrindingCity.Domain.Entities.Resource.Enums;
using MediatR;

namespace GrindingCity.Core.Building.Commands.Create
{
    public sealed class CreateBuildingCommand : IRequest<BuildingEntity>
    {
        public Guid DistrictId { get; init; }
        public string Name { get; init; } = default!;
        public string RawResource { get; init; }
        public int RawResourceAmount { get; init; }
        public string EndResource { get; init; }
        public int EndResourceAmount { get; init; }
    }
}
