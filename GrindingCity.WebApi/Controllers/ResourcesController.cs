using GrindingCity.Core.Resource.Commands.Create;
using GrindingCity.Domain.Interfaces.Entities;
using GrindingCity.WebApi.DTO.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrindingCity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResourcesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddResourceToBuildingDto dto)
        {
            var command = new CreateResourceCommand
            {
                BuildingId = dto.BuildingId,
                ResourceType = dto.ResourceType,
                Name = dto.Name,
                Amount = dto.Amount
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
