using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.DTOs;
public record GetBuildingResponse(Guid id, 
    decimal price, BuildingType type, IEnumerable<Resource> resources);
public record GetAllBuildingsResponse(IEnumerable<Guid> ids);

