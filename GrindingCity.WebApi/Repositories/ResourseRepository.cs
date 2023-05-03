using GrindingCity.WebApi.DTOs;
using GrindingCity.WebApi.Interfaces;
using GrindingCity.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GrindingCity.WebApi.Repositories
{
    public class ResourseRepository : IResourseRepository
    {
        private AppDbContext _appDbContext;

        public ResourseRepository(AppDbContext db) 
        {
            _appDbContext = db;
        }

        public async Task<Resourse?> GetResourseAsync(Guid id) => await _appDbContext.Resourses.FirstOrDefaultAsync(b => b.Id == id);

        public async Task<IEnumerable<Resourse>> GetAllResoursesAsync() 
        {
            return await _appDbContext.Resourses.ToListAsync();
        }

        public async Task AddResourseAsync(CreateResourseRequest request)
        {
            var newResourse = new Resourse()
            {
                Title = request.title,
                Price = request.price,
                BuildingId = request.buildingId
            };

            _appDbContext.Resourses.Add(newResourse);

            await _appDbContext.SaveChangesAsync();
        }
        
        public async Task UpdateResourseAsync(Guid id, UpdateResourseRequest request)
        {
            var resourse = new Resourse()
            {
                Id = id,
                Title = request.title,
                Price = request.price,
                BuildingId = request.buildingId
            };

            _appDbContext.Update(resourse);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteResourseAsync(Guid id)
        {
            var resourse = new Resourse() { Id = id };

            _appDbContext.Resourses.Remove(resourse);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
