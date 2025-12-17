//using System.Linq.Expressions;
//using Coink.Microservice.Domain.Entities.AssignedNumber;
//using Coink.Microservice.Domain.Exceptions;
//using Coink.Microservice.Domain.Ports;
//using Coink.Microservice.Domain.Service;
//using Domain.Test.DataBuilder.DTO_s;
//using Domain.Test.DataBuilder.Entity;
//using NSubstitute;
//using NSubstitute.ExceptionExtensions;

//namespace Domain.Test
//{
//    public class AssignedNumberServiceTest
//    {
//        private readonly IRepository<AssignedNumberEntity> _mockRepository;
//        private readonly AssignedNumberService _assignedNumberService;

//        public AssignedNumberServiceTest()
//        {
//            _mockRepository = Substitute.For<IRepository<AssignedNumberEntity>>();
//            _assignedNumberService = new AssignedNumberService(_mockRepository);
//        }

//        [Fact]
//        public async Task CreateAssignedNumberAsync_ValidRequest_ReturnsAssignedNumberEntity()
//        {
//            // Arrange
//            var productId = Guid.NewGuid();
//            var userId = Guid.NewGuid();
//            var request = new AssignedNumberCreateRequestDtoBuilder()
//                .WithProductId(productId)
//                .Build();
//            var assignedNumberEntity = new AssignedNumberEntityBuilder()
//                .WithProductId(productId)
//                .WithUserId(userId)
//                .Build();

//            _mockRepository.GetAsync(
//                assignedNumber => assignedNumber.ProductId == request.ProductId
//            ).Returns(new List<AssignedNumberEntity>() { assignedNumberEntity });

//            _mockRepository.AddAsync(
//                assignedNumberEntity
//            ).ReturnsForAnyArgs(assignedNumberEntity);

//            // Act
//            var result = await _assignedNumberService
//                .CreateAssignedNumberAsync(request);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(userId, result.UserId);
//            Assert.Equal(productId, result.ProductId);
//            await _mockRepository.Received(1)
//                .AddAsync(Arg.Any<AssignedNumberEntity>());
//            await _mockRepository.Received(1)
//                .GetAsync(Arg.Any<Expression<Func<AssignedNumberEntity, bool>>>());
//        }

//        [Fact]
//        public async Task CreateAssignedNumberAsync_InvalidProductId_ThrowsArgumentNullException()
//        {
//            // Arrange
//            var request = new AssignedNumberCreateRequestDtoBuilder()
//                .WithProductId(Guid.Empty)
//                .Build();

//            // Act & Assert
//            await Assert.ThrowsAsync<ValidationException>(() =>
//                _assignedNumberService.CreateAssignedNumberAsync(request)
//            );
//        }

//        [Fact]
//        public async Task CreateAssignedNumberAsync_InvalidUserId_ThrowsArgumentNullException()
//        {
//            // Arrange
//            var request = new AssignedNumberCreateRequestDtoBuilder()
//                .WithUserId(Guid.Empty)
//                .Build();

//            // Act & Assert
//            await Assert.ThrowsAsync<ValidationException>(() =>
//                _assignedNumberService.CreateAssignedNumberAsync(request)
//            );
//        }

//        [Fact]
//        public async Task GenerateUniqueNumberAsync_NoAvailableNumbers_ThrowsInvalidOperationException()
//        {
//            // Arrange
//            var productId = Guid.NewGuid();
//            var request = new AssignedNumberCreateRequestDtoBuilder()
//                .WithProductId(productId)
//                .Build();
//            var assignedNumbers = Enumerable.Range(1, 99999)
//                .Select(x => x.ToString("D5")).ToList();
//            string messageException = "No existen números disponibles.";

//            _mockRepository.GetAsync(
//                Arg.Any<Expression<Func<AssignedNumberEntity, bool>>>()
//            ).ThrowsAsync(new InvalidOperationException("DefaultException"));

//            // Act
//            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
//                _assignedNumberService.CreateAssignedNumberAsync(request)
//            );

//            // Assert
//            Assert.Equal(messageException, ex.Message);
//        }

//        [Fact]
//        public async Task GenerateUniqueNumberAsync_NoAvailableNumbers_ThrowsException()
//        {
//            // Arrange
//            var productId = Guid.NewGuid();
//            var request = new AssignedNumberCreateRequestDtoBuilder()
//                .WithProductId(productId)
//                .Build();
//            var assignedNumbers = Enumerable.Range(1, 99999)
//                .Select(x => x.ToString("D5")).ToList();
//            string messageException = "Ocurrió un error tratando de asignar un número.";

//            _mockRepository.GetAsync(
//                Arg.Any<Expression<Func<AssignedNumberEntity, bool>>>()
//            ).ThrowsAsync(new Exception("DefaultException"));

//            // Act
//            var ex = await Assert.ThrowsAsync<RestClientException>(() =>
//                _assignedNumberService.CreateAssignedNumberAsync(request)
//            );

//            // Assert
//            Assert.Equal(messageException, ex.Message);
//        }
//    }
//}
