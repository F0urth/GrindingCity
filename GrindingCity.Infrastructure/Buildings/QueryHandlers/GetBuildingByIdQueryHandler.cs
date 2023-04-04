using CSharpFunctionalExtensions;
using Domain.Buildings.Providers;
using Domain.Buildings.Queries;
using Domain.Entities;
using MediatR;

namespace GrindingCity.Infrastructure.Buildings.QueryHandlers;

public sealed class GetBuildingByIdQueryHandler : IRequestHandler<GetBuildingByIdQuery, Result<BuildingEntity, string>>
{
    private readonly IBuildingRepository _repository;

    public GetBuildingByIdQueryHandler(IBuildingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BuildingEntity, string>> Handle(GetBuildingByIdQuery query, CancellationToken cancellationToken)
    {
        var building = await _repository.GetBuildingByAsync(query.Id);
        if (building.HasNoValue)
        {
            return Result.Failure<BuildingEntity, string>("");
        }

        return building.Value;
    }
}