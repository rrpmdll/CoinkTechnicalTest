using System.Resources;
using Coink.Microservice.Domain.IResources;

namespace Coink.Microservice.Infrastructure.Resources
{
    public class MessagesProvider : IMessagesProvider
    {
        private readonly ResourceManager _resourceManager;

        public MessagesProvider()
        {
            _resourceManager = new ResourceManager("Coink.Microservice.Infrastructure.Resources.Messages", typeof(MessagesProvider).Assembly);
        }

        public string UserNotFound => _resourceManager.GetString("UserNotFound")!;
        public string CountryNotFound => _resourceManager.GetString("CountryNotFound")!;
        public string DepartmentNotFound => _resourceManager.GetString("DepartmentNotFound")!;
        public string MunicipalityNotFound => _resourceManager.GetString("MunicipalityNotFound")!;
        public string MunicipalityDoesNotExist => _resourceManager.GetString("MunicipalityDoesNotExist")!;
        public string UserCreateFailed => _resourceManager.GetString("UserCreateFailed")!;
        public string UserUpdateFailed => _resourceManager.GetString("UserUpdateFailed")!;
    }
}
