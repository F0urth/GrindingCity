using Domain.Districts.Commands;
using Domain.Districts.Providers;
using MediatR;

namespace GrindingCity.Infrastructure.Districts.CommandHandlers;

public sealed class RemoveDistrictByIdCommandHandler : IRequestHandler<RemoveDistrictByIdCommand, Unit>
{
    private readonly IDistrictRepository _repository;

    public RemoveDistrictByIdCommandHandler(IDistrictRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveDistrictByIdCommand command, CancellationToken cancellationToken)
    {
        await _repository.RemoveDistrictAsync(command.Id);
        return Unit.Value;
    }
}