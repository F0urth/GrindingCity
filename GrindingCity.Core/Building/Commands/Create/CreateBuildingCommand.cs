using GrindingCity.Domain.Entities.Building;
using MediatR;

namespace GrindingCity.Core.Building.Commands.Create
{
    public sealed class CreateBuildingCommand : IRequest<BuildingEntity>
    {
        public string Name { get; init; }
    }
}
