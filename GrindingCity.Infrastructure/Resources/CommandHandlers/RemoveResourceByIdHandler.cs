using Domain.Buildings.Providers;
using Domain.Resources.Commands;
using MediatR;

namespace GrindingCity.Infrastructure.Resources.CommandHandlers;

public sealed class RemoveResourceByIdHandler : IRequestHandler<RemoveResourceByIdCommand, Unit>
{
    private readonly IBuildingRepository _repository;

    public RemoveResourceByIdHandler(IBuildingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveResourceByIdCommand command, CancellationToken cancellationToken)
    {
        await _repository.RemoveBuildingAsync(command.Id);
        return Unit.Value;
    }
}