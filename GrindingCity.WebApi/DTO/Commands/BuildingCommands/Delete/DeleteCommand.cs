using MediatR;

namespace GrindingCity.WebApi.DTO.Commands.BuildingCommands.Delete
{
    public class DeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
