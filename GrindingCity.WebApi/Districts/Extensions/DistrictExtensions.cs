using Domain.Entities;
using Domain.Districts.Commands;
using GrindingCity.WebApi.Districts.Models;

namespace GrindingCity.WebApi.Districts.Extensions
{
    public static class DistrictExtensions
    {
        public static ReadDistrictDto ToReadDto(this DistrictEntity entity) =>
        new()
        {
            Id = entity.Id,
            Name = entity.Name,
        };


        public static AddDistrictCommand ToAddDistrictCommand(this InputDistrictDto dto) =>
            new(dto.Name);
    }
}
