using Coink.Microservice.Application.Feature.User.Commands;

namespace Api.Test.DataBuilder.CQRS
{
    public class UserDeleteCommandBuilder
    {
        private Guid _id;

        public UserDeleteCommandBuilder()
        {
            _id = Guid.NewGuid();
        }

        public UserDeleteCommand Build()
            => new UserDeleteCommand(_id);

        public UserDeleteCommandBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
    }
}