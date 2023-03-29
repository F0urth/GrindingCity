using GrindingCity.Core.Interfaces.Infrastructure.Repositories;
using GrindingCity.Domain.Models;
using MediatR;

namespace GrindingCity.WebApi.DTO.Queries.BuildingQueries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Building>
    {
        private readonly IBuildingRepository _buildingRepository;

        public GetByIdQueryHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<Building> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(request.Id));
            }

            var building = await _buildingRepository.GetById(request.Id);

            return building;
        }
    }
}
