namespace GrindingCity.Infrastructure.Building.QueryHandlers;

using CSharpFunctionalExtensions;
using Domain.Building.Providers;
using Domain.Building.Query;
using Domain.Entities;
using MediatR;

public sealed class GetBuildingByIdQueryHandler : IRequestHandler<GetBuildingByIdQuery, Result<BuildingEntity, string>>
{
    private readonly IBuildingRepository _repository;

    public GetBuildingByIdQueryHandler(IBuildingRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BuildingEntity, string>> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
    {
        var building = await _repository.GetBuildingByAsync(request.Id);
        if (building.HasNoValue)
        {
            return Result.Failure<BuildingEntity, string>("");
        }

        return building.Value;
    }
}