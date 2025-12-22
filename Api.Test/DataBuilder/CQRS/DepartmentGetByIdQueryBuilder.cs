using Coink.Microservice.Application.Feature.Location.Queries;

namespace Api.Test.DataBuilder.CQRS
{
    public class DepartmentGetByIdQueryBuilder
    {
        private Guid _id;

        public DepartmentGetByIdQueryBuilder()
        {
            _id = Guid.NewGuid();
        }

        public DepartmentGetByIdQuery Build()
            => new DepartmentGetByIdQuery(_id);

        public DepartmentGetByIdQueryBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
    }
}