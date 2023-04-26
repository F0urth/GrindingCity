using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.DTOs;

public record CreateBuildingRequest(decimal price, BuildingType buildingType);
public record UpdateBuildingRequest(decimal price, BuildingType buildingType);
public record CreateResourseRequest(string title, decimal price);
public record UpdateResourseRequest(string title, decimal price);
