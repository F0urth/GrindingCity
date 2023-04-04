using Domain.Entities;

namespace GrindingCity.WebApi.Resources.Models;

public sealed class ReadResourceDto
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public double WeightPerUnit { get; init; }

    public ResourceRarity Rarity { get; init; }
}