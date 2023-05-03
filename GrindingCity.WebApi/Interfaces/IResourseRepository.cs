using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Models;

namespace GrindingCity.WebApi.Interfaces
{
    public interface IResourseRepository
    {
        public Task<Resourse?> GetResourseAsync(Guid id);
        public Task<IEnumerable<Resourse>> GetAllResoursesAsync();
        public Task AddResourseAsync(CreateResourseRequest building);
        public Task UpdateResourseAsync(Guid id, UpdateResourseRequest price);
        public Task DeleteResourseAsync(Guid id);
    }
}
