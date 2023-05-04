using MediatR;

namespace Domain.Resources.Commands;

public sealed record RemoveResourceByIdCommand(Guid Id) : IRequest<Unit>;