using Coink.Microservice.Application.Feature.User.Commands;

namespace Api.Test.DataBuilder.CQRS
{
    public class UserUpdateCommandBuilder
    {
        private Guid _id;
        private string _name;
        private string _phone;
        private string _address;
        private Guid _municipalityId;

        public UserUpdateCommandBuilder()
        {
            _id = Guid.NewGuid();
            _name = "Jane Doe";
            _phone = "0987654321";
            _address = "456 Elm St";
            _municipalityId = Guid.NewGuid();
        }

        public UserUpdateCommand Build()
            => new UserUpdateCommand
            {
                Id = _id,
                Name = _name,
                Phone = _phone,
                Address = _address,
                MunicipalityId = _municipalityId
            };

        public UserUpdateCommandBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public UserUpdateCommandBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UserUpdateCommandBuilder WithPhone(string phone)
        {
            _phone = phone;
            return this;
        }

        public UserUpdateCommandBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }

        public UserUpdateCommandBuilder WithMunicipalityId(Guid municipalityId)
        {
            _municipalityId = municipalityId;
            return this;
        }
    }
}