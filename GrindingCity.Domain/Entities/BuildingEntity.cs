namespace Domain.Entities;

public class BuildingEntity
{
    public Guid Id { get; set; }

    public BuildingType BuildingType { get; set; }

    public bool IsPurchased { get; set; }
    
    public decimal Price { get; set; }

    public int BuildingLevel { get; set; }
    
    public int NumberOfGuards { get; set; }

}

public enum BuildingType
{
    None,
    Hotel,
}
