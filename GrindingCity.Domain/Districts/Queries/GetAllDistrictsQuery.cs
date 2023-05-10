using Domain.Entities;
using MediatR;

namespace Domain.Districts.Queries;
public sealed record GetAllDistrictsQuery : IRequest<IEnumerable<DistrictEntity>>;
