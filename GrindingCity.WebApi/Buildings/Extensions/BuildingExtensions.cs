using Domain.Buildings.Commands;
using Domain.Entities;
using GrindingCity.WebApi.Buildings.Models;

namespace GrindingCity.WebApi.Buildings.Extensions;

public static class BuildingExtensions
{
    public static ReadBuildingDto ToReadDto(this BuildingEntity entity) =>
        new()
        {
            Id = entity.Id,
            BuildingType = entity.BuildingType,
            IsPurchased = entity.IsPurchased,
            Price = entity.Price,
            BuildingLevel = entity.BuildingLevel,
            NumberOfGuards = entity.NumberOfGuards
        };

    
    public static AddBuildingCommand ToAddBuildingCommand(this InputBuildingDto dto) =>
        new()
        {
            BuildingType = dto.BuildingType,
            IsPurchased = dto.IsPurchased,
            Price = dto.Price,
            BuildingLevel = dto.BuildingLevel,
            NumberOfGuards = dto.NumberOfGuards
        };
}