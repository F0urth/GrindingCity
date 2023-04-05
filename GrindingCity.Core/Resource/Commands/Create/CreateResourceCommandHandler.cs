using GrindingCity.Domain.Interfaces.Entities;
using GrindingCity.Domain.Interfaces.Repositories;
using MediatR;

namespace GrindingCity.Core.Resource.Commands.Create
{
    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, IResource>
    {
        private readonly IResourcesRepository _resourcesRepository;

        public CreateResourceCommandHandler(IResourcesRepository resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        //public Task<IResource> Handle(CreateResourceCommand command, CancellationToken cancellationToken)
        //{
        //    var resource = 
        //}
    }
}
