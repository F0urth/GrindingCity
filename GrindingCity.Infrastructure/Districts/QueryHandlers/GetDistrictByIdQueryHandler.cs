using CSharpFunctionalExtensions;
using Domain.Buildings.Providers;
using Domain.Buildings.Queries;
using Domain.Districts.Providers;
using Domain.Districts.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindingCity.Infrastructure.Districts.QueryHandlers;
public sealed class GetDistrictByIdQueryHandler : IRequestHandler<GetDistrictByIdQuery, Result<DistrictEntity, string>>
{
    private readonly IDistrictRepository _repository;

    public GetDistrictByIdQueryHandler(IDistrictRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<DistrictEntity, string>> Handle(GetDistrictByIdQuery query, CancellationToken cancellationToken)
    {
        var building = await _repository.GetDistrictByAsync(query.Id);
        if (building.HasNoValue)
        {
            return Result.Failure<DistrictEntity, string>("");
        }

        return building.Value;
    }
}
