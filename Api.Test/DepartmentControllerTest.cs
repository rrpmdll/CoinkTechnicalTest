using Api.Test.DataBuilder.CQRS;
using Api.Test.DataBuilder.DTO_s;
using Coink.Microservice.Api.Controllers.Location;
using Coink.Microservice.Domain.DTOs.Location;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Api.Test
{
    public class DepartmentControllerTest
    {
        private readonly DepartmentController _controller;
        private readonly IMediator _mediator;

        public DepartmentControllerTest()
        {
            _mediator = Substitute.For<IMediator>();
            _controller = new DepartmentController(_mediator);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnOkResult_WithDepartmentDtos()
        {
            // Arrange
            var expectedDtos = new List<DepartmentDto>
            {
                new DepartmentDtoBuilder().Build(),
                new DepartmentDtoBuilder().Build()
            };

            _mediator.Send(Arg.Any<Coink.Microservice.Application.Feature.Location.Queries.DepartmentGetAllQuery>())
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
            await _mediator.Received(1).Send(Arg.Any<Coink.Microservice.Application.Feature.Location.Queries.DepartmentGetAllQuery>());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnOkResult_WithDepartmentDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedDto = new DepartmentDtoBuilder().WithId(id).Build();

            _mediator.Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.DepartmentGetByIdQuery>(q => q.Id == id))
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
            await _mediator.Received(1).Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.DepartmentGetByIdQuery>(q => q.Id == id));
        }

        [Fact]
        public async Task GetByCountryIdAsync_ShouldReturnOkResult_WithDepartmentDtos()
        {
            // Arrange
            var countryId = Guid.NewGuid();
            var expectedDtos = new List<DepartmentDto>
            {
                new DepartmentDtoBuilder().WithCountryId(countryId).Build(),
                new DepartmentDtoBuilder().WithCountryId(countryId).Build()
            };

            _mediator.Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.DepartmentGetByCountryIdQuery>(q => q.CountryId == countryId))
                .Returns(expectedDtos);

            // Act
            var result = await _controller.GetByCountryIdAsync(countryId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedDtos, okResult.Value);
        }

        [Fact]
        public async Task GetByCountryIdAsync_ShouldCallMediatorSend_Once()
        {
            // Arrange
            var countryId = Guid.NewGuid();

            // Act
            await _controller.GetByCountryIdAsync(countryId);

            // Assert
            await _mediator.Received(1).Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.DepartmentGetByCountryIdQuery>(q => q.CountryId == countryId));
        }
    }
}