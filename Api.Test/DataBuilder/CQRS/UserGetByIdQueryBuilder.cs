using Coink.Microservice.Application.Feature.User.Queries;

namespace Api.Test.DataBuilder.CQRS
{
    public class UserGetByIdQueryBuilder
    {
        private Guid _id;

        public UserGetByIdQueryBuilder()
        {
            _id = Guid.NewGuid();
        }

        public UserGetByIdQuery Build()
            => new UserGetByIdQuery(_id);

        public UserGetByIdQueryBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
    }
}