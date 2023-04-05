using GrindingCity.Domain.Entities.Building;
using GrindingCity.Domain.Interfaces.Repositories;
using MediatR;

namespace GrindingCity.Core.Building.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, BuildingEntity>
    {
        private readonly IBuildingRepository _buildingRepository;

        public GetByIdQueryHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<BuildingEntity> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(request.Id));
            }

            var building = await _buildingRepository.GetByIdAsync(request.Id);

            return building;
        }
    }
}
