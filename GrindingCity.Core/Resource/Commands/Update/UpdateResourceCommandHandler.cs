using GrindingCity.Domain.Interfaces.Repositories;
using MediatR;

namespace GrindingCity.Core.Resource.Commands.Update
{
    public class UpdateResourceCommandHandler : IRequestHandler<UpdateResourceCommand, bool>
    {
        private readonly IResourcesRepository _resourcesRepository;

        public UpdateResourceCommandHandler(IResourcesRepository resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        public async Task<bool> Handle(UpdateResourceCommand command, CancellationToken cancellationToken)
        {
            var resource = await _resourcesRepository.GetByIdAsync(command.Id);

            resource.GetType();

            return true;
        }
    }
}
