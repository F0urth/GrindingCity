using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Interfaces
{
    public interface IResourseRepository
    {
        public Task<Resourse?> GetResourse(Guid id);
        public Task<IEnumerable<Resourse>> GetAllResourses();
        public Task AddResourse(CreateResourseRequest building);
        public Task UpdateResourse(Guid id, CreateResourseRequest price);
        public Task DeleteResourse(Guid id);
    }
}
