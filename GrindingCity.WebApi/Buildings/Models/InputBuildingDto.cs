using Domain.Entities;

namespace GrindingCity.WebApi.Buildings.Models;

public sealed class InputBuildingDto
{
    public BuildingType BuildingType { get; init; }

    public bool IsPurchased { get; init; }
    
    public decimal Price { get; init; }

    public int BuildingLevel { get; init; }
    
    public int NumberOfGuards { get; init; }
}