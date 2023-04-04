using CSharpFunctionalExtensions;
using Domain.Buildings.Commands;
using Domain.Buildings.Providers;
using Domain.Entities;
using GrindingCity.Infrastructure.Buildings.Extensions;
using MediatR;

namespace GrindingCity.Infrastructure.Buildings.CommandHandlers;

public sealed class AddBuildingCommandHandler : IRequestHandler<AddBuildingCommand, Result<BuildingEntity, string>>
{
    private readonly IBuildingRepository _repository;

    public AddBuildingCommandHandler(IBuildingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BuildingEntity, string>> Handle(AddBuildingCommand command, CancellationToken cancellationToken)
    {
        var buildingEntity = command.ToEntity();
        var addBuilding = await _repository.AddBuildingAsync(buildingEntity);
        return addBuilding;
    }
}