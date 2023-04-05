using GrindingCity.Domain.Interfaces.Repositories;
using MediatR;

namespace GrindingCity.Core.Building.Commands.Delete
{
    public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand, bool>
    {
        private readonly IBuildingRepository _buildingRepository;

        public DeleteBuildingCommandHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<bool> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            await _buildingRepository.DeleteAsync(request.Id);

            return true;
        }
    }
}
