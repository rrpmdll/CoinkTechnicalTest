using Api.Test.DataBuilder.CQRS;
using Api.Test.DataBuilder.DTO_s;
using Coink.Microservice.Api.Controllers.User;
using Coink.Microservice.Domain.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Api.Test
{
    public class UserControllerTest
    {
        private readonly UserController _controller;
        private readonly IMediator _mediator;

        public UserControllerTest()
        {
            _mediator = Substitute.For<IMediator>();
            _controller = new UserController(_mediator);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedResult_WithUserDto()
        {
            // Arrange
            var command = new UserCreateCommandBuilder().Build();
            var expectedDto = new UserDtoBuilder().Build();

            _mediator.Send(command).Returns(expectedDto);

            // Act
            var result = await _controller.CreateAsync(command);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
            Assert.Equal(expectedDto, createdResult.Value);
            Assert.Equal($"api/User/{expectedDto.Id}", createdResult.Location);
        }

        [Fact]
        public async Task CreateAsync_ShouldCallMediatorSend_Once()
        {
            // Arrange
            var command = new UserCreateCommandBuilder().Build();
            var expectedDto = new UserDtoBuilder().Build();

            _mediator.Send(command).Returns(expectedDto);

            // Act
            await _controller.CreateAsync(command);

            // Assert
            await _mediator.Received(1).Send(command);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnOkResult_WithUserDtos()
        {
            // Arrange
            var expectedDtos = new List<UserDto>
            {
                new UserDtoBuilder().Build(),
                new UserDtoBuilder().Build()
            };

            _mediator.Send(Arg.Any<Coink.Microservice.Application.Feature.User.Queries.UserGetAllQuery>())
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
            await _mediator.Received(1).Send(Arg.Any<Coink.Microservice.Application.Feature.User.Queries.UserGetAllQuery>());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnOkResult_WithUserDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedDto = new UserDtoBuilder().WithId(id).Build();

            _mediator.Send(Arg.Is<Coink.Microservice.Application.Feature.User.Queries.UserGetByIdQuery>(q => q.Id == id))
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
            await _mediator.Received(1).Send(Arg.Is<Coink.Microservice.Application.Feature.User.Queries.UserGetByIdQuery>(q => q.Id == id));
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnOkResult_WithUserDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new UserUpdateCommandBuilder().WithId(Guid.Empty).Build(); // Id will be set in controller
            var expectedDto = new UserDtoBuilder().WithId(id).Build();

            _mediator.Send(Arg.Is<Coink.Microservice.Application.Feature.User.Commands.UserUpdateCommand>(c => c.Id == id))
                .Returns(expectedDto);

            // Act
            var result = await _controller.UpdateAsync(id, command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedDto, okResult.Value);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallMediatorSend_WithCorrectId()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new UserUpdateCommandBuilder().WithId(Guid.Empty).Build();

            // Act
            await _controller.UpdateAsync(id, command);

            // Assert
            await _mediator.Received(1).Send(Arg.Is<Coink.Microservice.Application.Feature.User.Commands.UserUpdateCommand>(c => c.Id == id));
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnNoContentResult()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mediator.Send(Arg.Is<Coink.Microservice.Application.Feature.User.Commands.UserDeleteCommand>(c => c.Id == id))
                .Returns(true);

            // Act
            var result = await _controller.DeleteAsync(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallMediatorSend_Once()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _controller.DeleteAsync(id);

            // Assert
            await _mediator.Received(1).Send(Arg.Is<Coink.Microservice.Application.Feature.User.Commands.UserDeleteCommand>(c => c.Id == id));
        }
    }
}