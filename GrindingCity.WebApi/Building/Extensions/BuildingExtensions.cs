namespace GrindingCity.WebApi.Building.Extensions;

using Domain.Building.Command;
using Domain.Entities;
using Models;

public static class BuildingExtensions
{
    public static BuildingDto ToDto(this BuildingEntity entity) =>
        new()
        {
            Id = entity.Id,
            BuildingType = entity.BuildingType,
            IsPurchased = entity.IsPurchased,
            Price = entity.Price,
            BuildingLevel = entity.BuildingLevel,
            NumberOfGuards = entity.NumberOfGuards
        };

    
    public static AddBuildingCommand ToAddBuildingCommand(this BuildingDto dto) =>
        new()
        {
            BuildingType = dto.BuildingType,
            IsPurchased = dto.IsPurchased,
            Price = dto.Price,
            BuildingLevel = dto.BuildingLevel,
            NumberOfGuards = dto.NumberOfGuards
        };
}