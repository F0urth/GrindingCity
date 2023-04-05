using GrindingCity.Core.Building.Commands.Update;
using GrindingCity.Domain.Interfaces.Repositories;
using MediatR;

namespace GrindingCity.GrindingCity.Core.Building.Commands.Update
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand, bool>
    {
        private readonly IBuildingRepository _buildingRepository;

        public UpdateBuildingCommandHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<bool> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetByIdAsync(request.Id);

            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            building.Name = request.Name;

            await _buildingRepository.UpdateAsync(building);

            return true;
        }
    }
}
