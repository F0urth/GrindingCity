using Domain.Buildings.Command;
using Domain.Buildings.Providers;
using MediatR;

namespace GrindingCity.Infrastructure.Buildings.CommandHandlers;

public sealed class RemoveBuildingByIdCommandHandler : IRequestHandler<RemoveBuildingByIdCommand, Unit>
{
    private readonly IBuildingRepository _repository;

    public RemoveBuildingByIdCommandHandler(IBuildingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveBuildingByIdCommand request, CancellationToken cancellationToken)
    {
        await _repository.RemoveBuildingAsync(request.Id);
        return Unit.Value;
    }
}