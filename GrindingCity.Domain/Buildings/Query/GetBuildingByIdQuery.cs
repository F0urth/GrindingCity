using CSharpFunctionalExtensions;
using Domain.Entities;
using MediatR;

namespace Domain.Buildings.Query;

public sealed record GetBuildingByIdQuery(Guid Id) : IRequest<Result<BuildingEntity, string>>;