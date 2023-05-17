namespace GrindingCity.WebApi.Models
{
    public class Resource
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Guid BuildingId { get; set; }
    }
}
