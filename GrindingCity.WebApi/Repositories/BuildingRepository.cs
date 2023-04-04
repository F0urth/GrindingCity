using GrindingCity.WebApi.Repositories;
using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Models;
using System;
using System.Collections;

namespace GrindingCity.WebApi.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private AppDbContext _appDbContext;

        public BuildingRepository(AppDbContext db)
        {
            _appDbContext = db;
        }

        public Building GetBuilding(Guid id) => _appDbContext.Buildings.FirstOrDefault(b => b.Id == id);
        public IEnumerable<Building> GetAllBuildings() => _appDbContext.Buildings.ToList();

        public void AddBuiding(Building building)
        {
            _appDbContext.Buildings.Add(building);
            _appDbContext.SaveChanges();
        }
        public void UpdateBuiding(Guid id, decimal price)
        {
            var building = _appDbContext.Buildings.FirstOrDefault(b => b.Id == id);

            if (building != null)
            {
                building.Price = price;
                _appDbContext.Update(building);
                _appDbContext.SaveChanges();
            }
        }

        public void DeleteBuiding(Guid id)
        {
            var building = _appDbContext.Buildings.FirstOrDefault(b => b.Id == id);

            if (building != null)
            {
                _appDbContext.Buildings.Remove(building);
                _appDbContext.SaveChanges();
            }
        }
    }
}
