using Coink.Microservice.Domain.Entities.User;
using Coink.Microservice.Domain.Exceptions;
using Coink.Microservice.Domain.IResources;
using Coink.Microservice.Domain.Repositories;

namespace Coink.Microservice.Domain.Service.User
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMunicipalityRepository _municipalityRepository;
        private readonly IMessagesProvider _messages;

        public UserService(
            IUserRepository userRepository,
            IMunicipalityRepository municipalityRepository,
            IMessagesProvider messages)
        {
            _userRepository = userRepository;
            _municipalityRepository = municipalityRepository;
            _messages = messages;
        }

        public async Task<UserEntity?> CreateAsync(string name, string phone, string address, Guid municipalityId)
        {
            var municipalityExists = await _municipalityRepository.ExistsAsync(municipalityId);
            if (!municipalityExists)
                throw new ValidationException(string.Format(_messages.MunicipalityDoesNotExist, municipalityId));

            var entity = await _userRepository.CreateAsync(name, phone, address, municipalityId);

            if (entity == null)
                throw new AppException(_messages.UserCreateFailed);

            return entity;
        }

        public async Task<UserEntity> GetByIdAsync(Guid id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            
            if (entity == null)
                throw new NotFoundException(string.Format(_messages.UserNotFound, id));

            return entity;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserEntity?> UpdateAsync(Guid id, string name, string phone, string address, Guid municipalityId)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                throw new NotFoundException(string.Format(_messages.UserNotFound, id));

            var municipalityExists = await _municipalityRepository.ExistsAsync(municipalityId);
            if (!municipalityExists)
                throw new ValidationException(string.Format(_messages.MunicipalityDoesNotExist, municipalityId));

            var entity = await _userRepository.UpdateAsync(id, name, phone, address, municipalityId);

            if (entity == null)
                throw new AppException(_messages.UserUpdateFailed);

            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                throw new NotFoundException(string.Format(_messages.UserNotFound, id));

            return await _userRepository.DeleteAsync(id);
        }
    }
}
