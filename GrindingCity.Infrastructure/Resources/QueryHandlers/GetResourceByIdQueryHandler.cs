using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Resources.Providers;
using Domain.Resources.Queries;
using MediatR;

namespace GrindingCity.Infrastructure.Resources.QueryHandlers;

public sealed class GetResourceByIdQueryHandler : IRequestHandler<GetResourceByIdQuery, Result<ResourceEntity, string>>
{
    private readonly IResourceRepository _repository;

    public GetResourceByIdQueryHandler(IResourceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ResourceEntity, string>> Handle(GetResourceByIdQuery query, CancellationToken cancellationToken)
    {
        var building = await _repository.GetResourceByAsync(query.Id);
        if (building.HasNoValue)
        {
            return Result.Failure<ResourceEntity, string>("");
        }

        return building.Value;
    }
}