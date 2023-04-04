using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Resources.Commands;
using Domain.Resources.Providers;
using GrindingCity.Infrastructure.Resources.Extensions;
using MediatR;

namespace GrindingCity.Infrastructure.Resources.CommandHandlers;

public sealed class AddResourceCommandHandler : IRequestHandler<AddResourceCommand, Result<ResourceEntity, string>>
{
    private readonly IResourceRepository _repository;

    public AddResourceCommandHandler(IResourceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ResourceEntity, string>> Handle(AddResourceCommand request, CancellationToken cancellationToken)
    {
        var buildingEntity = request.ToEntity();
        var addBuilding = await _repository.AddBuildingAsync(buildingEntity);
        return addBuilding;
    }
}