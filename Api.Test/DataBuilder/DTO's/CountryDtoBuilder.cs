using Coink.Microservice.Domain.DTOs.Location;

namespace Api.Test.DataBuilder.DTO_s
{
    public class CountryDtoBuilder
    {
        private Guid _id;
        private string _name;
        private string _code;
        private bool _isActive;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public CountryDtoBuilder()
        {
            _id = Guid.NewGuid();
            _name = "Colombia";
            _code = "CO";
            _isActive = true;
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;
        }

        public CountryDto Build()
        {
            return new CountryDto
            {
                Id = _id,
                Name = _name,
                Code = _code,
                IsActive = _isActive,
                CreatedAt = _createdAt,
                UpdatedAt = _updatedAt
            };
        }

        public CountryDtoBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public CountryDtoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CountryDtoBuilder WithCode(string code)
        {
            _code = code;
            return this;
        }

        public CountryDtoBuilder WithIsActive(bool isActive)
        {
            _isActive = isActive;
            return this;
        }

        public CountryDtoBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public CountryDtoBuilder WithUpdatedAt(DateTime? updatedAt)
        {
            _updatedAt = updatedAt;
            return this;
        }
    }
}