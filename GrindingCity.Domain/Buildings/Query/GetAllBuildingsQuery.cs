using Domain.Entities;
using MediatR;

namespace Domain.Buildings.Query;

public sealed record GetAllBuildingsQuery : IRequest<IEnumerable<BuildingEntity>>;