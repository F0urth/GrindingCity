namespace Domain.Building.Command;

using CSharpFunctionalExtensions;
using Entities;
using MediatR;

public sealed class AddBuildingCommand : IRequest<Result<Guid, string>>
{
    public BuildingType BuildingType { get; init; }

    public bool IsPurchased { get; init; }
    
    public decimal Price { get; init; }

    public int BuildingLevel { get; init; }
    
    public int NumberOfGuards { get; init; }
}