namespace GrindingCity.Infrastructure.Building.QueryHandlers;

using Domain.Building.Providers;
using Domain.Building.Query;
using Domain.Entities;
using MediatR;

public sealed class GetAllBuildingsQueryHandler : IRequestHandler<GetAllBuildingsQuery, IEnumerable<BuildingEntity>>
{
    private readonly IBuildingRepository _repository;

    public GetAllBuildingsQueryHandler(IBuildingRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BuildingEntity>> Handle(GetAllBuildingsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllBuildingsAsync();
    }
}