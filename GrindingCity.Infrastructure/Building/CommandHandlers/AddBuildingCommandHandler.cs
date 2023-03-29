namespace GrindingCity.Infrastructure.Building.CommandHandlers;

using CSharpFunctionalExtensions;
using Domain.Building.Command;
using Domain.Building.Providers;
using Extensions;
using MediatR;

public sealed class AddBuildingCommandHandler : IRequestHandler<AddBuildingCommand, Result<Guid, string>>
{
    private readonly IBuildingRepository _repository;

    public AddBuildingCommandHandler(IBuildingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid, string>> Handle(AddBuildingCommand request, CancellationToken cancellationToken)
    {
        var buildingEntity = request.ToEntity();
        var addBuilding = await _repository.AddBuildingAsync(buildingEntity);
        return addBuilding.Id;
    }
}