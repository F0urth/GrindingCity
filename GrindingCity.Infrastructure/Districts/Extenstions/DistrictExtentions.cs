using Domain.Buildings.Commands;
using Domain.Districts.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindingCity.Infrastructure.Districts.Extenstions
{
    public static class DistrictExtentions
    {
        public static DistrictEntity ToEntity(this AddDistrictCommand command) =>
        new()
        {
            Id = Guid.NewGuid(),
            Name = command.Name
        };
    }
}
