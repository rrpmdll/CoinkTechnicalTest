using Coink.Microservice.Application.Feature.Location.Queries;

namespace Api.Test.DataBuilder.CQRS
{
    public class MunicipalityGetByDepartmentIdQueryBuilder
    {
        private Guid _departmentId;

        public MunicipalityGetByDepartmentIdQueryBuilder()
        {
            _departmentId = Guid.NewGuid();
        }

        public MunicipalityGetByDepartmentIdQuery Build()
            => new MunicipalityGetByDepartmentIdQuery(_departmentId);

        public MunicipalityGetByDepartmentIdQueryBuilder WithDepartmentId(Guid departmentId)
        {
            _departmentId = departmentId;
            return this;
        }
    }
}