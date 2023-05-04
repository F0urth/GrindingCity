using MediatR;

namespace Domain.Buildings.Commands;

public sealed record RemoveBuildingByIdCommand(Guid Id) : IRequest<Unit>;