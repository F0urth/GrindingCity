namespace Domain.Building.Query;

using CSharpFunctionalExtensions;
using Entities;
using MediatR;

public sealed record GetBuildingByIdQuery(Guid Id) : IRequest<Result<BuildingEntity, string>>;