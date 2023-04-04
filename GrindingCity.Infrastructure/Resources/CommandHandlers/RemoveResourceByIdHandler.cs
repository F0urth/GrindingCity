using Domain.Buildings.Providers;
using Domain.Resources.Commands;
using MediatR;

namespace GrindingCity.Infrastructure.Resources.CommandHandlers;

public sealed class RemoveResourceByIdHandler : IRequestHandler<RemoveResourceById, Unit>
{
    private readonly IBuildingRepository _repository;

    public RemoveResourceByIdHandler(IBuildingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveResourceById request, CancellationToken cancellationToken)
    {
        await _repository.RemoveBuildingAsync(request.Id);
        return Unit.Value;
    }
}