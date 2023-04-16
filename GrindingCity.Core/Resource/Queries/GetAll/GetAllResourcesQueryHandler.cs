using GrindingCity.Core.Extensions.Sort;
using GrindingCity.Domain.Interfaces.Entities;
using GrindingCity.Domain.Interfaces.Repositories;
using MediatR;

namespace GrindingCity.Core.Resource.Queries.GetAll
{
    public class GetAllResourcesQueryHandler : IRequestHandler<GetAllResourcesQuery, IEnumerable<IResource>>
    {
        private readonly IResourcesRepository _resourcesRepository;

        public GetAllResourcesQueryHandler(IResourcesRepository resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        public Task<IEnumerable<IResource>> Handle(GetAllResourcesQuery query, CancellationToken cancellationToken)
        {
            var getAll = _resourcesRepository.GetAllAsync(query.BuildingId).Result;

            var leftIndex = getAll.Select(x => x.Amount).First();
            var rightIndex = getAll.Select(x => x.Amount).Last();

            var array = getAll.ToArray();

            var result = query.Sort ? QuickSortImplementation.CustomQuickSort(array, leftIndex, rightIndex) : getAll;

            return Task.FromResult(result);
        }
    }
}
