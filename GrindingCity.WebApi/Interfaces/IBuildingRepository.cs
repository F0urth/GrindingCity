using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Interfaces
{
    public interface IBuildingRepository
    {
        public Building GetBuilding(Guid id);
        public IEnumerable<Building> GetAllBuildings();
        public void AddBuiding(Building building);
        public void UpdateBuiding(Guid id, decimal price);
        public void DeleteBuiding(Guid id);
    }
}
