using GrindingCity.Domain.Models;
using MediatR;

namespace GrindingCity.WebApi.DTO.Queries.BuildingQueries.GetById
{
    public class GetByIdQuery : IRequest<Building>
    {
        public Guid Id { get; set; }
    }
}
