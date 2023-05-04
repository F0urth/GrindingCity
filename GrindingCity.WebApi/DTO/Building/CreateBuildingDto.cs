using GrindingCity.Domain.Entities.Resource.Enums;

namespace GrindingCity.WebApi.DTO.Building
{
    public sealed record CreateBuildingDto(
        Guid districtId,
        string name,
        RawResourcesNames rawResource,
        int rawResourceAmount,
        EndResourceNames endResource,
        int endResourceAmount);
}
