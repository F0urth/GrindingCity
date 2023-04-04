using MediatR;

namespace Domain.Resources.Commands;

public sealed record RemoveResourceById(Guid Id) : IRequest<Unit>;