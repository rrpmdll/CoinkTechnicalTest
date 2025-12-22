using Coink.Microservice.Domain.Entities.User;
using Coink.Microservice.Domain.Exceptions;
using Coink.Microservice.Domain.IResources;
using Coink.Microservice.Domain.Repositories;
using Coink.Microservice.Domain.Service.User;
using Domain.Test.DataBuilder.Entity;
using NSubstitute;

namespace Domain.Test
{
    public class UserServiceTest
    {
        private readonly IUserRepository _mockUserRepository;
        private readonly IMunicipalityRepository _mockMunicipalityRepository;
        private readonly IMessagesProvider _mockMessages;
        private readonly UserService _userService;

        public UserServiceTest()
        {
            _mockUserRepository = Substitute.For<IUserRepository>();
            _mockMunicipalityRepository = Substitute.For<IMunicipalityRepository>();
            _mockMessages = Substitute.For<IMessagesProvider>();
            _userService = new UserService(_mockUserRepository, _mockMunicipalityRepository, _mockMessages);
        }

        [Fact]
        public async Task CreateAsync_ValidRequest_ReturnsUserEntity()
        {
            // Arrange
            var name = "John Doe";
            var phone = "1234567890";
            var address = "123 Main St";
            var municipalityId = Guid.NewGuid();
            var userEntity = new UserEntityBuilder()
                .WithName(name)
                .WithPhone(phone)
                .WithAddress(address)
                .WithMunicipalityId(municipalityId)
                .Build();

            _mockMunicipalityRepository.ExistsAsync(municipalityId).Returns(true);
            _mockUserRepository.CreateAsync(name, phone, address, municipalityId).Returns(userEntity);

            // Act
            var result = await _userService.CreateAsync(name, phone, address, municipalityId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(phone, result.Phone);
            Assert.Equal(address, result.Address);
            Assert.Equal(municipalityId, result.MunicipalityId);
            await _mockMunicipalityRepository.Received(1).ExistsAsync(municipalityId);
            await _mockUserRepository.Received(1).CreateAsync(name, phone, address, municipalityId);
        }

        [Fact]
        public async Task CreateAsync_MunicipalityDoesNotExist_ThrowsValidationException()
        {
            // Arrange
            var name = "John Doe";
            var phone = "1234567890";
            var address = "123 Main St";
            var municipalityId = Guid.NewGuid();
            var message = "Municipality does not exist";

            _mockMunicipalityRepository.ExistsAsync(municipalityId).Returns(false);
            _mockMessages.MunicipalityDoesNotExist.Returns(message);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ValidationException>(() =>
                _userService.CreateAsync(name, phone, address, municipalityId)
            );
            Assert.Equal(string.Format(message, municipalityId), ex.Message);
        }

        [Fact]
        public async Task CreateAsync_CreateFails_ThrowsAppException()
        {
            // Arrange
            var name = "John Doe";
            var phone = "1234567890";
            var address = "123 Main St";
            var municipalityId = Guid.NewGuid();
            var message = "User create failed";

            _mockMunicipalityRepository.ExistsAsync(municipalityId).Returns(true);
            _mockUserRepository.CreateAsync(name, phone, address, municipalityId).Returns((UserEntity?)null);
            _mockMessages.UserCreateFailed.Returns(message);

            // Act & Assert
            await Assert.ThrowsAsync<AppException>(() =>
                _userService.CreateAsync(name, phone, address, municipalityId)
            );
        }

        [Fact]
        public async Task GetByIdAsync_UserExists_ReturnsUserEntity()
        {
            // Arrange
            var id = Guid.NewGuid();
            var userEntity = new UserEntityBuilder().WithId(id).Build();

            _mockUserRepository.GetByIdAsync(id).Returns(userEntity);

            // Act
            var result = await _userService.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            await _mockUserRepository.Received(1).GetByIdAsync(id);
        }

        [Fact]
        public async Task GetByIdAsync_UserNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var message = "User not found";

            _mockUserRepository.GetByIdAsync(id).Returns((UserEntity?)null);
            _mockMessages.UserNotFound.Returns(message);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<NotFoundException>(() =>
                _userService.GetByIdAsync(id)
            );
            Assert.Equal(string.Format(message, id), ex.Message);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllUsers()
        {
            // Arrange
            var users = new List<UserEntity>
            {
                new UserEntityBuilder().Build(),
                new UserEntityBuilder().Build()
            };

            _mockUserRepository.GetAllAsync().Returns(users);

            // Act
            var result = await _userService.GetAllAsync();

            // Assert
            Assert.Equal(users, result);
            await _mockUserRepository.Received(1).GetAllAsync();
        }

        [Fact]
        public async Task UpdateAsync_ValidRequest_ReturnsUserEntity()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Jane Doe";
            var phone = "0987654321";
            var address = "456 Elm St";
            var municipalityId = Guid.NewGuid();
            var existingUser = new UserEntityBuilder().WithId(id).Build();
            var updatedUser = new UserEntityBuilder()
                .WithId(id)
                .WithName(name)
                .WithPhone(phone)
                .WithAddress(address)
                .WithMunicipalityId(municipalityId)
                .Build();

            _mockUserRepository.GetByIdAsync(id).Returns(existingUser);
            _mockMunicipalityRepository.ExistsAsync(municipalityId).Returns(true);
            _mockUserRepository.UpdateAsync(id, name, phone, address, municipalityId).Returns(updatedUser);

            // Act
            var result = await _userService.UpdateAsync(id, name, phone, address, municipalityId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            Assert.Equal(name, result.Name);
            Assert.Equal(phone, result.Phone);
            Assert.Equal(address, result.Address);
            Assert.Equal(municipalityId, result.MunicipalityId);
            await _mockUserRepository.Received(1).GetByIdAsync(id);
            await _mockMunicipalityRepository.Received(1).ExistsAsync(municipalityId);
            await _mockUserRepository.Received(1).UpdateAsync(id, name, phone, address, municipalityId);
        }

        [Fact]
        public async Task UpdateAsync_UserNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Jane Doe";
            var phone = "0987654321";
            var address = "456 Elm St";
            var municipalityId = Guid.NewGuid();
            var message = "User not found";

            _mockUserRepository.GetByIdAsync(id).Returns((UserEntity?)null);
            _mockMessages.UserNotFound.Returns(message);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<NotFoundException>(() =>
                _userService.UpdateAsync(id, name, phone, address, municipalityId)
            );
            Assert.Equal(string.Format(message, id), ex.Message);
        }

        [Fact]
        public async Task UpdateAsync_MunicipalityDoesNotExist_ThrowsValidationException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Jane Doe";
            var phone = "0987654321";
            var address = "456 Elm St";
            var municipalityId = Guid.NewGuid();
            var existingUser = new UserEntityBuilder().WithId(id).Build();
            var message = "Municipality does not exist";

            _mockUserRepository.GetByIdAsync(id).Returns(existingUser);
            _mockMunicipalityRepository.ExistsAsync(municipalityId).Returns(false);
            _mockMessages.MunicipalityDoesNotExist.Returns(message);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ValidationException>(() =>
                _userService.UpdateAsync(id, name, phone, address, municipalityId)
            );
            Assert.Equal(string.Format(message, municipalityId), ex.Message);
        }

        [Fact]
        public async Task UpdateAsync_UpdateFails_ThrowsAppException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Jane Doe";
            var phone = "0987654321";
            var address = "456 Elm St";
            var municipalityId = Guid.NewGuid();
            var existingUser = new UserEntityBuilder().WithId(id).Build();
            var message = "User update failed";

            _mockUserRepository.GetByIdAsync(id).Returns(existingUser);
            _mockMunicipalityRepository.ExistsAsync(municipalityId).Returns(true);
            _mockUserRepository.UpdateAsync(id, name, phone, address, municipalityId).Returns((UserEntity?)null);
            _mockMessages.UserUpdateFailed.Returns(message);

            // Act & Assert
            await Assert.ThrowsAsync<AppException>(() =>
                _userService.UpdateAsync(id, name, phone, address, municipalityId)
            );
        }

        [Fact]
        public async Task DeleteAsync_UserExists_ReturnsTrue()
        {
            // Arrange
            var id = Guid.NewGuid();
            var existingUser = new UserEntityBuilder().WithId(id).Build();

            _mockUserRepository.GetByIdAsync(id).Returns(existingUser);
            _mockUserRepository.DeleteAsync(id).Returns(true);

            // Act
            var result = await _userService.DeleteAsync(id);

            // Assert
            Assert.True(result);
            await _mockUserRepository.Received(1).GetByIdAsync(id);
            await _mockUserRepository.Received(1).DeleteAsync(id);
        }

        [Fact]
        public async Task DeleteAsync_UserNotFound_ThrowsNotFoundException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var message = "User not found";

            _mockUserRepository.GetByIdAsync(id).Returns((UserEntity?)null);
            _mockMessages.UserNotFound.Returns(message);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<NotFoundException>(() =>
                _userService.DeleteAsync(id)
            );
            Assert.Equal(string.Format(message, id), ex.Message);
        }
    }
}