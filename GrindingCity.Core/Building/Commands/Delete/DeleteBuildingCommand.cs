using MediatR;

namespace GrindingCity.Core.Building.Commands.Delete
{
    public sealed record DeleteBuildingCommand(Guid Id) : IRequest<bool>;
}
