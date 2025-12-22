using Coink.Microservice.Domain.Entities.User;

namespace Domain.Test.DataBuilder.Entity
{
    public class UserEntityBuilder
    {
        private Guid _id;
        private string _name;
        private string _phone;
        private string _address;
        private Guid _municipalityId;
        private bool _isActive;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public UserEntityBuilder()
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

        public UserEntity Build()
        {
            return new UserEntity
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

        public UserEntityBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public UserEntityBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UserEntityBuilder WithPhone(string phone)
        {
            _phone = phone;
            return this;
        }

        public UserEntityBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }

        public UserEntityBuilder WithMunicipalityId(Guid municipalityId)
        {
            _municipalityId = municipalityId;
            return this;
        }

        public UserEntityBuilder WithIsActive(bool isActive)
        {
            _isActive = isActive;
            return this;
        }

        public UserEntityBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public UserEntityBuilder WithUpdatedAt(DateTime? updatedAt)
        {
            _updatedAt = updatedAt;
            return this;
        }
    }
}