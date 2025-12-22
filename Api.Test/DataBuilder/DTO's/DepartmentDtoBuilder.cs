using Coink.Microservice.Domain.DTOs.Location;

namespace Api.Test.DataBuilder.DTO_s
{
    public class DepartmentDtoBuilder
    {
        private Guid _id;
        private string _name;
        private string _code;
        private Guid _countryId;
        private bool _isActive;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public DepartmentDtoBuilder()
        {
            _id = Guid.NewGuid();
            _name = "Antioquia";
            _code = "05";
            _countryId = Guid.NewGuid();
            _isActive = true;
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;
        }

        public DepartmentDto Build()
        {
            return new DepartmentDto
            {
                Id = _id,
                Name = _name,
                Code = _code,
                CountryId = _countryId,
                IsActive = _isActive,
                CreatedAt = _createdAt,
                UpdatedAt = _updatedAt
            };
        }

        public DepartmentDtoBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public DepartmentDtoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public DepartmentDtoBuilder WithCode(string code)
        {
            _code = code;
            return this;
        }

        public DepartmentDtoBuilder WithCountryId(Guid countryId)
        {
            _countryId = countryId;
            return this;
        }

        public DepartmentDtoBuilder WithIsActive(bool isActive)
        {
            _isActive = isActive;
            return this;
        }

        public DepartmentDtoBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public DepartmentDtoBuilder WithUpdatedAt(DateTime? updatedAt)
        {
            _updatedAt = updatedAt;
            return this;
        }
    }
}