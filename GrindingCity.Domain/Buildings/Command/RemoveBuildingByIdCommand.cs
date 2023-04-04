using MediatR;

namespace Domain.Buildings.Command;

public sealed record RemoveBuildingByIdCommand(Guid Id) : IRequest<Unit>;