using Coink.Microservice.Application.Feature.Location.Queries;

namespace Api.Test.DataBuilder.CQRS
{
    public class DepartmentGetByCountryIdQueryBuilder
    {
        private Guid _countryId;

        public DepartmentGetByCountryIdQueryBuilder()
        {
            _countryId = Guid.NewGuid();
        }

        public DepartmentGetByCountryIdQuery Build()
            => new DepartmentGetByCountryIdQuery(_countryId);

        public DepartmentGetByCountryIdQueryBuilder WithCountryId(Guid countryId)
        {
            _countryId = countryId;
            return this;
        }
    }
}