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
        
        public async Task<Resourse?> GetResourse(Guid id) => await _appDbContext.Resourses.FirstOrDefaultAsync(b => b.Id == id);
        
        public async Task<IEnumerable<Resourse>> GetAllResourses() => await _appDbContext.Resourses.ToListAsync();

        public async Task AddResourse(CreateResourseRequest request)
        {
            var newResourse = new Resourse()
            {
                Title = request.title,
                Price = request.price
            };

            _appDbContext.Resourses.Add(newResourse);
            await _appDbContext.SaveChangesAsync();
        }
        
        public async Task UpdateResourse(Guid id, CreateResourseRequest request)
        {
            var resourse = new Resourse()
            {
                Id = id,
                Title = request.title,
                Price = request.price
            };

            _appDbContext.Update(resourse);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteResourse(Guid id)
        {
            var resourse = await _appDbContext.Resourses.FirstOrDefaultAsync(b => b.Id == id);

            if (resourse != null)
            {
                _appDbContext.Resourses.Remove(resourse);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
