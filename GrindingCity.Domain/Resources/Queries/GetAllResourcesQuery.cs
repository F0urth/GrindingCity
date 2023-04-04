using Domain.Entities;
using MediatR;

namespace Domain.Resources.Queries;

public record GetAllResourcesQuery : IRequest<IEnumerable<ResourceEntity>>;