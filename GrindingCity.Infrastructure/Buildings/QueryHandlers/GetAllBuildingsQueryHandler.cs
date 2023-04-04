using Domain.Buildings.Providers;
using Domain.Buildings.Queries;
using Domain.Entities;
using MediatR;

namespace GrindingCity.Infrastructure.Buildings.QueryHandlers;

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