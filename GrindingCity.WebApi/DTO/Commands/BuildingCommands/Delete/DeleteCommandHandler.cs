using GrindingCity.Core.Interfaces.Infrastructure.Repositories;
using MediatR;

namespace GrindingCity.WebApi.DTO.Commands.BuildingCommands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IBuildingRepository _buildingRepository;

        public DeleteCommandHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            await _buildingRepository.Delete(request.Id);

            return true;
        }
    }
}
