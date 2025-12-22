using Api.Test.DataBuilder.CQRS;
using Api.Test.DataBuilder.DTO_s;
using Coink.Microservice.Api.Controllers.Location;
using Coink.Microservice.Domain.DTOs.Location;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Api.Test
{
    public class MunicipalityControllerTest
    {
        private readonly MunicipalityController _controller;
        private readonly IMediator _mediator;

        public MunicipalityControllerTest()
        {
            _mediator = Substitute.For<IMediator>();
            _controller = new MunicipalityController(_mediator);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnOkResult_WithMunicipalityDtos()
        {
            // Arrange
            var expectedDtos = new List<MunicipalityDto>
            {
                new MunicipalityDtoBuilder().Build(),
                new MunicipalityDtoBuilder().Build()
            };

            _mediator.Send(Arg.Any<Coink.Microservice.Application.Feature.Location.Queries.MunicipalityGetAllQuery>())
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
            await _mediator.Received(1).Send(Arg.Any<Coink.Microservice.Application.Feature.Location.Queries.MunicipalityGetAllQuery>());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnOkResult_WithMunicipalityDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedDto = new MunicipalityDtoBuilder().WithId(id).Build();

            _mediator.Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.MunicipalityGetByIdQuery>(q => q.Id == id))
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
            await _mediator.Received(1).Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.MunicipalityGetByIdQuery>(q => q.Id == id));
        }

        [Fact]
        public async Task GetByDepartmentIdAsync_ShouldReturnOkResult_WithMunicipalityDtos()
        {
            // Arrange
            var departmentId = Guid.NewGuid();
            var expectedDtos = new List<MunicipalityDto>
            {
                new MunicipalityDtoBuilder().WithDepartmentId(departmentId).Build(),
                new MunicipalityDtoBuilder().WithDepartmentId(departmentId).Build()
            };

            _mediator.Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.MunicipalityGetByDepartmentIdQuery>(q => q.DepartmentId == departmentId))
                .Returns(expectedDtos);

            // Act
            var result = await _controller.GetByDepartmentIdAsync(departmentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedDtos, okResult.Value);
        }

        [Fact]
        public async Task GetByDepartmentIdAsync_ShouldCallMediatorSend_Once()
        {
            // Arrange
            var departmentId = Guid.NewGuid();

            // Act
            await _controller.GetByDepartmentIdAsync(departmentId);

            // Assert
            await _mediator.Received(1).Send(Arg.Is<Coink.Microservice.Application.Feature.Location.Queries.MunicipalityGetByDepartmentIdQuery>(q => q.DepartmentId == departmentId));
        }
    }
}