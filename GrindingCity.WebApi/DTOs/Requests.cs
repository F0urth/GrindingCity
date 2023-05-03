using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.DTOs;

public record CreateBuildingRequest(decimal price, BuildingType buildingType);
public record UpdateBuildingRequest(decimal price, BuildingType buildingType);
public record CreateResourceRequest(string title, decimal price, Guid buildingId);
public record UpdateResourceRequest(string title, decimal price, Guid buildingId);
