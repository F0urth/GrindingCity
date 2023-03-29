namespace Domain.Building.Command;

using MediatR;

public sealed record RemoveBuildingByIdCommand(Guid Id) : IRequest<Unit>;