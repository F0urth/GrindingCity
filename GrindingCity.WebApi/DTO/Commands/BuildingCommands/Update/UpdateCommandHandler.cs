using GrindingCity.Core.Interfaces.Infrastructure.Repositories;
using MediatR;

namespace GrindingCity.WebApi.DTO.Commands.BuildingCommands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IBuildingRepository _buildingRepository;

        public UpdateCommandHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetById(request.Id);

            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            building.Name = request.Name;

            await _buildingRepository.Update(building);

            return true;
        }
    }
}
