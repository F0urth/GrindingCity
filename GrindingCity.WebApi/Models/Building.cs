namespace GrindingCity.WebApi.Models;
public class Building
{
    public Guid Id { get; set; }

    public decimal Price { get; set; }

    public BuildingType Type { get; set; }
}

