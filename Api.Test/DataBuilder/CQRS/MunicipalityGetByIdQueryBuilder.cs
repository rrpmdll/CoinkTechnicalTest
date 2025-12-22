using Coink.Microservice.Application.Feature.Location.Queries;

namespace Api.Test.DataBuilder.CQRS
{
    public class MunicipalityGetByIdQueryBuilder
    {
        private Guid _id;

        public MunicipalityGetByIdQueryBuilder()
        {
            _id = Guid.NewGuid();
        }

        public MunicipalityGetByIdQuery Build()
            => new MunicipalityGetByIdQuery(_id);

        public MunicipalityGetByIdQueryBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
    }
}