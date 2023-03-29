using GrindingCity.Core.Interfaces.Infrastructure.Repositories;
using GrindingCity.Domain.Models;
using MediatR;

namespace GrindingCity.WebApi.DTO.Commands.BuildingCommands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, Building>
    {
        private readonly IBuildingRepository _buildingRepository;

        public CreateCommandHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<Building> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var building = new Building()
            {
                Name = request.Name
            };

            await _buildingRepository.Post(building);

            return building;
        }
    }
}
