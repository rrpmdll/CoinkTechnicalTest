using Coink.Microservice.Application.Feature.Location.Queries;
using Coink.Microservice.Domain.DTOs.Location;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coink.Microservice.Api.Controllers.Location
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CountryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new CountryGetAllQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CountryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new CountryGetByIdQuery(id));
            return Ok(result);
        }
    }
}
