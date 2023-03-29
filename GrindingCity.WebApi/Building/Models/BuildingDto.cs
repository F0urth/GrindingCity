namespace GrindingCity.WebApi.Building.Models;

using Domain.Entities;

public sealed class BuildingDto
{
    public Guid Id { get; init; }

    public BuildingType BuildingType { get; init; }

    public bool IsPurchased { get; init; }
    
    public decimal Price { get; init; }

    public int BuildingLevel { get; init; }
    
    public int NumberOfGuards { get; init; }
}