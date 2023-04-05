using GrindingCity.Domain.Entities.Building;
using GrindingCity.Domain.Interfaces.Repositories;
using MediatR;

namespace GrindingCity.Core.Building.Commands.Create
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, BuildingEntity>
    {
        private readonly IBuildingRepository _buildingRepository;

        public CreateBuildingCommandHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<BuildingEntity> Handle(CreateBuildingCommand command, CancellationToken cancellationToken)
        {
            var building = new BuildingEntity()
            {
                Name = command.Name
            };

            await _buildingRepository.CreateAsync(building);

            return building;
        }
    }
}
