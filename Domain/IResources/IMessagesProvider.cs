namespace Coink.Microservice.Domain.IResources
{
    public interface IMessagesProvider
    {
        string UserNotFound { get; }
        string CountryNotFound { get; }
        string DepartmentNotFound { get; }
        string MunicipalityNotFound { get; }
        string MunicipalityDoesNotExist { get; }
        string UserCreateFailed { get; }
        string UserUpdateFailed { get; }
    }
}
