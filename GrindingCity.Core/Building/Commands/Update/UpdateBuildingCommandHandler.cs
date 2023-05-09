using GrindingCity.Core.Building.Commands.Update;
using GrindingCity.Domain.Interfaces.Repositories;
using MediatR;

namespace GrindingCity.GrindingCity.Core.Building.Commands.Update
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand, string>
    {
        private readonly IBuildingRepository _buildingRepository;

        public UpdateBuildingCommandHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<string> Handle(UpdateBuildingCommand command, CancellationToken cancellationToken)
        {
            var isSuccess =  Random.Shared.Next(1, 100);
            var message = "Your supplies were stolen!";
            var building = await _buildingRepository.GetByIdAsync(command.Id);

            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            if (isSuccess > 60)
            {
                message = "Transport successful!";

                building.Resources.Where(x => x.Name == command.RawResourceName)
                                  .Select(x => x.Amount = command.RawResourceAmount);
                building.Resources.Where(x => x.Name == command.EndResourceName)
                                  .Select(x => x.Amount = command.EndResourceAmount);
            }

            building.Name = command.Name;

            await _buildingRepository.UpdateAsync(building);

            return message;
        }
    }
}
