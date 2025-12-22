using Coink.Microservice.Application.Feature.Location.Queries;

namespace Api.Test.DataBuilder.CQRS
{
    public class CountryGetByIdQueryBuilder
    {
        private Guid _id;

        public CountryGetByIdQueryBuilder()
        {
            _id = Guid.NewGuid();
        }

        public CountryGetByIdQuery Build()
            => new CountryGetByIdQuery(_id);

        public CountryGetByIdQueryBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
    }
}