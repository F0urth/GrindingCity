using GrindingCity.Domain.Entities.Resource.Enums;

namespace GrindingCity.WebApi.DTO.Building
{
    public sealed record CreateBuildingDto(
        Guid districtId,
        string name,
        string rawResourceName,
        int rawResourceAmount,
        string endResourceName,
        int endResourceAmount);
}
