using GrindingCity.Domain.Interfaces.Entities;
using MediatR;

namespace GrindingCity.Core.Resource.Queries.GetAll
{
    public sealed class GetAllResourcesQuery : IRequest<IEnumerable<IResource>>
    {
        public Guid BuildingId { get; set; }
        public bool Sort { get; set; }
    }
}
