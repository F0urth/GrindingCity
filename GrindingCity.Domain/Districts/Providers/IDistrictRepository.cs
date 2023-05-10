using CSharpFunctionalExtensions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Districts.Providers
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<DistrictEntity>> GetAllDistrictsAsync();

        Task<Maybe<DistrictEntity>> GetDistrictByAsync(Guid id);

        Task<DistrictEntity> AddDistrictAsync(DistrictEntity entity);

        Task RemoveDistrictAsync(Guid id);
    }
}
