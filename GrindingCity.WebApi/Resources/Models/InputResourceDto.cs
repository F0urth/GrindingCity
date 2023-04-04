using Domain.Entities;

namespace GrindingCity.WebApi.Resources.Models;

public sealed class InputResourceDto
{
    public string Name { get; init; } = default!;

    public double WeightPerUnit { get; init; }

    public ResourceRarity Rarity { get; init; }
}