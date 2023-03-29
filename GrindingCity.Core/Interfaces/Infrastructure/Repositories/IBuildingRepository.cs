using GrindingCity.Domain.Models;

namespace GrindingCity.Core.Interfaces.Infrastructure.Repositories
{
    public interface IBuildingRepository
    {
        public Task<Building> Post(Building building);
        public Task<Building> GetById(Guid id);
        public Task<bool> Update(Building building);
        public Task<bool> Delete(Guid id);
    }
}
