using GrindingCity.Core.Extensions.Enum;
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
                DistrictId = command.DistrictId,
                Name = command.Name,
                Resources = new List<ResourceEntity>()
            };

            var rawName = MapEnumName.MapRawEnumName(command.Name);

            if (rawName is not RawResourcesNames.None)
            {
                var rawResource = new RawResourceEntity(building.Id, rawName, command.RawResourceAmount);

                building.Resources.Add(rawResource);
            }

            var endName = MapEnumName.MapEndEnumName(command.Name);

            if (endName is not EndResourceNames.None)
            {
                var endResource = new EndResourceEntity(building.Id, endName, command.EndResourceAmount);

                building.Resources.Add(endResource);
            }

            await _buildingRepository.CreateAsync(building);

            return building;
        }
    }
}
