using CSharpFunctionalExtensions;
using Domain.Entities;
using MediatR;

namespace Domain.Resources.Queries;

public sealed record GetResourceByIdQuery(Guid Id) : IRequest<Result<ResourceEntity, string>>;