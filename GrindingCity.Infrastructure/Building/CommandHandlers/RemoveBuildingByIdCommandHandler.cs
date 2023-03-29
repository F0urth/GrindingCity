namespace GrindingCity.Infrastructure.Building.CommandHandlers;

using Domain.Building.Command;
using Domain.Building.Providers;
using MediatR;

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