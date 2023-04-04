using Domain.Entities;
using MediatR;

namespace Domain.Buildings.Queries;

public sealed record GetAllBuildingsQuery : IRequest<IEnumerable<BuildingEntity>>;