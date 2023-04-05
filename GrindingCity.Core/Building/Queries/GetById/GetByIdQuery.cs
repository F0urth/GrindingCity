using GrindingCity.Domain.Entities.Building;
using MediatR;

namespace GrindingCity.Core.Building.Queries.GetById
{
    public sealed record GetByIdQuery(Guid Id) : IRequest<BuildingEntity>;
}
