using Domain.Buildings.Command;
using Domain.Entities;

namespace GrindingCity.Infrastructure.Buildings.Extensions;

public static class BuildingExtensions
{
    public static BuildingEntity ToEntity(this AddBuildingCommand command) =>
        new()
        {
            Id = Guid.NewGuid(),
            BuildingType = command.BuildingType,
            IsPurchased = command.IsPurchased,
            Price = command.Price,
            BuildingLevel = command.BuildingLevel,
            NumberOfGuards = command.NumberOfGuards
        };
}