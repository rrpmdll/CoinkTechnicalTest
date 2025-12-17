using Coink.Microservice.Application.Feature.Location.Queries;
using Coink.Microservice.Domain.DTOs.Location;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coink.Microservice.Api.Controllers.Location
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MunicipalityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MunicipalityDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new MunicipalityGetAllQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MunicipalityDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new MunicipalityGetByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("department/{departmentId}")]
        [ProducesResponseType(typeof(IEnumerable<MunicipalityDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByDepartmentIdAsync(Guid departmentId)
        {
            var result = await _mediator.Send(new MunicipalityGetByDepartmentIdQuery(departmentId));
            return Ok(result);
        }
    }
}
