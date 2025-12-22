using Coink.Microservice.Application.Feature.User.Commands;

namespace Api.Test.DataBuilder.CQRS
{
    public class UserCreateCommandBuilder
    {
        private string _name;
        private string _phone;
        private string _address;
        private Guid _municipalityId;

        public UserCreateCommandBuilder()
        {
            _name = "John Doe";
            _phone = "1234567890";
            _address = "123 Main St";
            _municipalityId = Guid.NewGuid();
        }

        public UserCreateCommand Build()
            => new UserCreateCommand
            {
                Name = _name,
                Phone = _phone,
                Address = _address,
                MunicipalityId = _municipalityId
            };

        public UserCreateCommandBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UserCreateCommandBuilder WithPhone(string phone)
        {
            _phone = phone;
            return this;
        }

        public UserCreateCommandBuilder WithAddress(string address)
        {
            _address = address;
            return this;
        }

        public UserCreateCommandBuilder WithMunicipalityId(Guid municipalityId)
        {
            _municipalityId = municipalityId;
            return this;
        }
    }
}