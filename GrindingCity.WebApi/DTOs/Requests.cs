using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.DTOs;

public record CreateBuildingRequest(decimal price, BuildingType buildingType);
public record CreateResourseRequest(string title, decimal price);
