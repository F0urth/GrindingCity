using Domain.Buildings.Commands;
using Domain.Entities;
using Domain.Resources.Commands;
using GrindingCity.WebApi.Buildings.Models;
using GrindingCity.WebApi.Resources.Models;

namespace GrindingCity.WebApi.Resources.Extensions;

public static class ResourceExtensions
{
    public static ReadResourceDto ToReadDto(this ResourceEntity entity) =>
        new()
        {
            Id = entity.Id,
            Name = entity.Name,
            WeightPerUnit = entity.WeightPerUnit,
            Rarity = entity.Rarity,
        };

    
    public static AddResourceCommand ToAddResourceCommand(this InputResourceDto dto) =>
        new(dto.Name, dto.WeightPerUnit, dto.Rarity);
}