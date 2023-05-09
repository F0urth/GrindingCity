namespace GrindingCity.WebApi.DTO.Building
{
    public sealed record UpdateBuildingDto(
        Guid id,
        string name,
        string rawResourceName,
        int rawResourceAmount,
        string endResourceName,
        int endResourceAmount);
}
