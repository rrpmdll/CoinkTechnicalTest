using Api.Test.DataBuilder.CQRS;
using Api.Test.DataBuilder.DTO_s;
using Coink.Microservice.Api.Controllers.Location;
using Coink.Microservice.Domain.DTOs.Location;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Api.Test
{
    public class CountryControllerTest
    {
        private readonly CountryController _controller;
        private readonly IMediator _mediator;

        public CountryControllerTest()
        {
            _mediator = Substitute.For<IMediator>();
            _controller = new CountryController(_mediator);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnOkResult_WithCountryDtos()
        {
            // Arrange
            var expectedDtos = new List<CountryDto>
            {
                new CountryDtoBuilder().Build(),
                new CountryDtoBuilder().Build()
            };

            _mediator.Send(Arg.Any<Coink.Microservice.Application.Feature.Location.Queries.CountryGetAllQuery>())
                .Returns(expectedDtos);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedDtos, okResult.Value);
        }

        [Fact]
        public async Task GetAllAsync_ShouldCallMediatorSend_Once()
        {
            // Act
            await _controller.GetAllAsync();

            // Assert
            await _mediator.Received(1).Send(Arg.Any<Coink.Microservice.Application.Feature.Location.Queries.CountryGetAllQuery>());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnOkResult_WithCountryDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedDto = new CountryDtoBuilder().WithId(id).Build();

            _mediator.Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.CountryGetByIdQuery>(q => q.Id == id))
                .Returns(expectedDto);

            // Act
            var result = await _controller.GetByIdAsync(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedDto, okResult.Value);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldCallMediatorSend_Once()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _controller.GetByIdAsync(id);

            // Assert
            await _mediator.Received(1).Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.CountryGetByIdQuery>(q => q.Id == id));
        }
    }
}