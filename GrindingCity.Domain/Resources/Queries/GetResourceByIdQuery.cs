using CSharpFunctionalExtensions;
using Domain.Entities;
using MediatR;

namespace Domain.Resources.Queries;

public record GetResourceById(Guid Id) : IRequest<Result<ResourceEntity, string>>;