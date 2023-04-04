using Domain.Entities;
using Domain.Resources.Commands;

namespace GrindingCity.Infrastructure.Resources.Extensions;

public static class ResourceExtensions
{
    public static ResourceEntity ToEntity(this AddResourceCommand command) =>
        new()
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            WeightPerUnit = command.WeightPerUnit,
            Rarity = command.Rarity,
        };
}