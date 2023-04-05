using GrindingCity.Domain.Interfaces.Entities;
using MediatR;

namespace GrindingCity.Core.Resource.Commands.Create
{
    public sealed class CreateResourceCommand : IRequest<IResource>
    {
        public Guid BuildingId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
