using CSharpFunctionalExtensions;
using Domain.Entities;
using MediatR;

namespace Domain.Buildings.Commands;

public sealed class AddBuildingCommand : IRequest<Result<BuildingEntity, string>>
{
    public BuildingType BuildingType { get; init; }

    public bool IsPurchased { get; init; }
    
    public decimal Price { get; init; }

    public int BuildingLevel { get; init; }
    
    public int NumberOfGuards { get; init; }
}