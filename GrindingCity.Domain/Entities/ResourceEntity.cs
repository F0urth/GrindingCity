namespace Domain.Entities;

public class ResourceEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public double WeightPerUnit { get; set; }

    public ResourceRarity Rarity { get; set; }
}

public enum ResourceRarity
{
    None,
    Low,
    Medium,
    High
}