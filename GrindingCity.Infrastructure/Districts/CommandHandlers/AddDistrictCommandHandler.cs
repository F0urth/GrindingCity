using CSharpFunctionalExtensions;
using Domain.Districts.Commands;
using Domain.Districts.Providers;
using Domain.Entities;
using GrindingCity.Infrastructure.Districts.Extenstions;
using MediatR;

namespace GrindingCity.Infrastructure.Districts.CommandHandlers;
public sealed class AddDistrictCommandHandler : IRequestHandler<AddDistrictCommand, Result<DistrictEntity, string>>
{
    private readonly IDistrictRepository _repository;

    public AddDistrictCommandHandler(IDistrictRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<DistrictEntity, string>> Handle(AddDistrictCommand command, CancellationToken cancellationToken)
    {
        var buildingEntity = command.ToEntity();
        var addDistrict = await _repository.AddDistrictAsync(buildingEntity);
        return addDistrict;
    }
}
