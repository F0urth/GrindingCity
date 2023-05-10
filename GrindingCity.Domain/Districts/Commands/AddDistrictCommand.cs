using CSharpFunctionalExtensions;
using Domain.Entities;
using MediatR;

namespace Domain.Districts.Commands;
public sealed record AddDistrictCommand
    (string Name) : IRequest<Result<DistrictEntity, string>>;
