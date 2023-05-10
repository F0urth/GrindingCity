using Domain.Buildings.Commands;
using Domain.Buildings.Providers;
using MediatR;

namespace GrindingCity.Infrastructure.Buildings.CommandHandlers;

public sealed class RemoveDistrictByIdCommandHandler : IRequestHandler<RemoveBuildingByIdCommand, Unit>
{
    private readonly IBuildingRepository _repository;

    public RemoveDistrictByIdCommandHandler(IBuildingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveBuildingByIdCommand command, CancellationToken cancellationToken)
    {
        await _repository.RemoveBuildingAsync(command.Id);
        return Unit.Value;
    }
}