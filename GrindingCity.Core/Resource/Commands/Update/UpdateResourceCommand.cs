using MediatR;

namespace GrindingCity.Core.Resource.Commands.Update
{
    public class UpdateResourceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
    }
}
