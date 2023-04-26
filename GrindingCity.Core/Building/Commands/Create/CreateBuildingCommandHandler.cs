using GrindingCity.Domain.Entities.Building;
using GrindingCity.Domain.Entities.Resource;
using GrindingCity.Domain.Entities.Resource.Enums;
using GrindingCity.Domain.Interfaces.Entities;
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
                Name = command.Name,
                Resources = new List<IResource>()
            };

            if (command.RawResource is not RawResourcesNames.None)
            {
                var rawResource = new RawResourceEntity(building.Id, command.RawResource, command.RawResourceAmount);

                building.Resources.Add(rawResource);
            }

            if (command.EndResource is not EndResourceNames.None)
            {
                var endResource = new EndResourceEntity(building.Id, command.EndResource, command.EndResourceAmount);

                building.Resources.Add(endResource);
            }

            await _buildingRepository.CreateAsync(building);

            return building;
        }
    }
}
