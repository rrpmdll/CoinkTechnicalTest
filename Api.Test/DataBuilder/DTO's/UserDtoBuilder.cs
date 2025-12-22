using Coink.Microservice.Domain.DTOs.User;

namespace Api.Test.DataBuilder.DTO_s
{
    public class UserDtoBuilder
    {
        private Guid _id;
        private string _name;
        private string _phone;
        private string _address;
        private Guid _municipalityId;
        private bool _isActive;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public UserDtoBuilder()
        {
            _id = Guid.NewGuid();
            _name = "John Doe";
            _phone = "1234567890";
            _address = "123 Main St";
            _municipalityId = Guid.NewGuid();
            _isActive = true;
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;
        }

        public UserDto Build()
        {
            return new UserDto
            {
                Id = _id,
                Name = _name,
                Phone = _phone,
                Address = _address,
                MunicipalityId = _municipalityId,
                IsActive = _isActive,
                CreatedAt = _createdAt,
                UpdatedAt = _updatedAt
            };
        }

        public UserDtoBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public UserDtoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UserDtoBuilder WithPhone(string phone)
        {
            _phone = phone;
            return this;
        }

        public UserDtoBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }

        public UserDtoBuilder WithMunicipalityId(Guid municipalityId)
        {
            _municipalityId = municipalityId;
            return this;
        }

        public UserDtoBuilder WithIsActive(bool isActive)
        {
            _isActive = isActive;
            return this;
        }

        public UserDtoBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public UserDtoBuilder WithUpdatedAt(DateTime? updatedAt)
        {
            _updatedAt = updatedAt;
            return this;
        }
    }
}