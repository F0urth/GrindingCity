using MediatR;

namespace GrindingCity.WebApi.DTO.Commands.BuildingCommands.Update
{
    public class UpdateCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UpdateCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
