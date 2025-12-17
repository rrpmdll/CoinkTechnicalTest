using Coink.Microservice.Application.Feature.Location.Queries;
using Coink.Microservice.Domain.DTOs.Location;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coink.Microservice.Api.Controllers.Location
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new DepartmentGetAllQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DepartmentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new DepartmentGetByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("country/{countryId}")]
        [ProducesResponseType(typeof(IEnumerable<DepartmentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCountryIdAsync(Guid countryId)
        {
            var result = await _mediator.Send(new DepartmentGetByCountryIdQuery(countryId));
            return Ok(result);
        }
    }
}
