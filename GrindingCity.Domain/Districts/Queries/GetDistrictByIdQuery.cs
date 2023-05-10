using CSharpFunctionalExtensions;
using Domain.Entities;
using MediatR;

namespace Domain.Districts.Queries;
public sealed record GetDistrictByIdQuery(Guid Id) : IRequest<Result<DistrictEntity, string>>;
