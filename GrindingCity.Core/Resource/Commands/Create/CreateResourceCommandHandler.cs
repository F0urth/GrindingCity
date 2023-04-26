using GrindingCity.Core.Extensions.Enum;
using GrindingCity.Domain.Entities.Resource;
using GrindingCity.Domain.Entities.Resource.Enums;
using GrindingCity.Domain.Interfaces.Entities;
using GrindingCity.Domain.Interfaces.Repositories;
using MediatR;

namespace GrindingCity.Core.Resource.Commands.Create
{
    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand>
    {
        private readonly IResourcesRepository _resourcesRepository;

        public CreateResourceCommandHandler(IResourcesRepository resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        public async Task Handle(CreateResourceCommand command, CancellationToken cancellationToken)
        {
            IResource resource;

            switch (command.ResourceType)
            {
                case ResourceType.Raw:

                    var rawName = MapEnumName.MapRawEnumName(command.Name);
                    resource = new RawResourceEntity(command.BuildingId, rawName, command.Amount);
                    await _resourcesRepository.AddAsync(resource);

                    break;

                case ResourceType.End:

                    var endName = MapEnumName.MapEndEnumName(command.Name);
                    resource = new EndResourceEntity(command.BuildingId, endName, command.Amount);
                    await _resourcesRepository.AddAsync(resource);

                    break;

                default:
                    break;
            }
        }
    }
}
