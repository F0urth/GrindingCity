using MediatR;

namespace GrindingCity.Core.Building.Commands.Update
{
    public sealed class UpdateBuildingCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string RawResourceName { get; set; } = default!;
        public int RawResourceAmount { get; set; }
        public string EndResourceName { get; set; } = default!;
        public int EndResourceAmount { get; set; }
    }
}
