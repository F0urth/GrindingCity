using MediatR;

namespace Domain.Districts.Commands;
public sealed record RemoveDistrictByIdCommand(Guid Id) : IRequest<Unit>;
