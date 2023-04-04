using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Resources.Providers;
using Domain.Resources.Queries;
using MediatR;

namespace GrindingCity.Infrastructure.Resources.QueryHandlers;

public sealed class GetResourceByIdQueryHandler : IRequestHandler<GetResourceById, Result<ResourceEntity, string>>
{
    private readonly IResourceRepository _repository;

    public GetResourceByIdQueryHandler(IResourceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ResourceEntity, string>> Handle(GetResourceById request, CancellationToken cancellationToken)
    {
        var building = await _repository.GetBuildingByAsync(request.Id);
        if (building.HasNoValue)
        {
            return Result.Failure<ResourceEntity, string>("");
        }

        return building.Value;
    }
}