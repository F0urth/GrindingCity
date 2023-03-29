using GrindingCity.Domain.Models;
using MediatR;

namespace GrindingCity.WebApi.DTO.Commands.BuildingCommands.Create
{
    public class CreateCommand : IRequest<Building>
    {
        public string Name { get; set; }

        public CreateCommand(string name)
        {
            Name = name;
        }
    }
}
