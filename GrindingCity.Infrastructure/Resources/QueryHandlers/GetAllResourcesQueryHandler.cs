using Domain.Entities;
using Domain.Resources.Providers;
using Domain.Resources.Queries;
using MediatR;

namespace GrindingCity.Infrastructure.Resources.QueryHandlers;

public sealed class GetAllResourcesQueryHandler : IRequestHandler<GetAllResourcesQuery, IEnumerable<ResourceEntity>>
{
    private readonly IResourceRepository _repository;

    public GetAllResourcesQueryHandler(IResourceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ResourceEntity>> Handle(GetAllResourcesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllResourcesAsync();
    }
}