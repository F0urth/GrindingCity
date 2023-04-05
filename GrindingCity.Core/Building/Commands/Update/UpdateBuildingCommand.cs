using MediatR;

namespace GrindingCity.Core.Building.Commands.Update
{
    public sealed class UpdateBuildingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
