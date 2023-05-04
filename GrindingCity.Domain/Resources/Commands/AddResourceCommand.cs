using CSharpFunctionalExtensions;
using Domain.Entities;
using MediatR;

namespace Domain.Resources.Commands;

public sealed record AddResourceCommand
    (string Name, double WeightPerUnit, ResourceRarity Rarity) : IRequest<Result<ResourceEntity, string>>;
