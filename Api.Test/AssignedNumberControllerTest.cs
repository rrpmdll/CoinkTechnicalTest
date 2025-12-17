//using Api.Test.DataBuilder.CQRS;
//using Api.Test.DataBuilder.DTO_s;
//using Coink.Microservice.Api.Controllers;
//using Coink.Microservice.Application.DTO_s.AssignedNumber;
//using MediatR;
//using NSubstitute;

//namespace Api.Test
//{
//    public class AssignedNumberControllerTest
//    {
//        private readonly AssignedNumberController _controller;
//        private readonly IMediator _mediator;

//        public AssignedNumberControllerTest()
//        {
//            _mediator = Substitute.For<IMediator>();

//            _controller = new AssignedNumberController(_mediator);
//        }

//        [Fact]
//        public async Task CreateAssignedNumberAsync_ShouldReturnAssignedNumberDto_Ok()
//        {
//            // Arrange
//            var command = new AssignedNumberCreateCommandBuilder()
//                .Build();

//            var expectedDto = new AssignedNumberDtoBuilder()
//                .Build();

//            _mediator.Send(command)
//                .Returns(expectedDto);

//            // Act
//            var result = await _controller
//                .CreateAssignedNumberAsync(command);

//            // Assert
//            Assert.NotNull(result);
//            Assert.IsType<ParkingDto>(result);
//            Assert.Equal(expectedDto, result);
//        }

//        [Fact]
//        public async Task CreateAssignedNumberAsync_ShouldCallMediatorSend_WhenCommandIsCalled()
//        {
//            // Arrange
//            var command = new AssignedNumberCreateCommandBuilder()
//                .Build();

//            // Act
//            await _controller
//                .CreateAssignedNumberAsync(command);

//            // Assert
//            await _mediator.Received(1)
//                .Send(command);
//        }
//    }
//}
