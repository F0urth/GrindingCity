using Domain.Districts.Providers;
using Domain.Districts.Queries;
using Domain.Entities;
using MediatR;

namespace GrindingCity.Infrastructure.Districts.QueryHandlers;

public sealed class GetAllDistrictsQueryHandler : IRequestHandler<GetAllDistrictsQuery, IEnumerable<DistrictEntity>>
{
    private readonly IDistrictRepository _repository;

    public GetAllDistrictsQueryHandler(IDistrictRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DistrictEntity>> Handle(GetAllDistrictsQuery query, CancellationToken cancellationToken)
    {
        return await _repository.GetAllDistrictsAsync();
    }
}
