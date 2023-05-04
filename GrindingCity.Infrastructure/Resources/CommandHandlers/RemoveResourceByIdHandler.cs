using Domain.Resources.Commands;
using Domain.Resources.Providers;
using MediatR;

namespace GrindingCity.Infrastructure.Resources.CommandHandlers;

public sealed class RemoveResourceByIdHandler : IRequestHandler<RemoveResourceByIdCommand, Unit>
{
    private readonly IResourceRepository _repository;

    public RemoveResourceByIdHandler(IResourceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveResourceByIdCommand command, CancellationToken cancellationToken)
    {
        await _repository.RemoveResourceAsync(command.Id);
        return Unit.Value;
    }
}