namespace Domain.Building.Query;

using Entities;
using MediatR;

public sealed record GetAllBuildingsQuery : IRequest<IEnumerable<BuildingEntity>>;