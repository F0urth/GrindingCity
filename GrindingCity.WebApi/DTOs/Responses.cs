using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.DTOs;
public record GetBuildingResponse(Guid id,
    decimal price, BuildingType type, IEnumerable<Resource> resources);
public record GetAllBuildingsResponse(IEnumerable<Guid> ids);
public record GetResourcesResponse(Guid id, string title,
    decimal price, Guid buildingId);
public record GetAllResourcesResponse(IEnumerable<Guid> ids);