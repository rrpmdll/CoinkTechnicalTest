using Coink.Microservice.Domain.DTOs.Location;

namespace Api.Test.DataBuilder.DTO_s
{
    public class MunicipalityDtoBuilder
    {
        private Guid _id;
        private string _name;
        private string _code;
        private Guid _departmentId;
        private bool _isActive;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public MunicipalityDtoBuilder()
        {
            _id = Guid.NewGuid();
            _name = "Medellín";
            _code = "05001";
            _departmentId = Guid.NewGuid();
            _isActive = true;
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;
        }

        public MunicipalityDto Build()
        {
            return new MunicipalityDto
            {
                Id = _id,
                Name = _name,
                Code = _code,
                DepartmentId = _departmentId,
                IsActive = _isActive,
                CreatedAt = _createdAt,
                UpdatedAt = _updatedAt
            };
        }

        public MunicipalityDtoBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public MunicipalityDtoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public MunicipalityDtoBuilder WithCode(string code)
        {
            _code = code;
            return this;
        }

        public MunicipalityDtoBuilder WithDepartmentId(Guid departmentId)
        {
            _departmentId = departmentId;
            return this;
        }

        public MunicipalityDtoBuilder WithIsActive(bool isActive)
        {
            _isActive = isActive;
            return this;
        }

        public MunicipalityDtoBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public MunicipalityDtoBuilder WithUpdatedAt(DateTime? updatedAt)
        {
            _updatedAt = updatedAt;
            return this;
        }
    }
}