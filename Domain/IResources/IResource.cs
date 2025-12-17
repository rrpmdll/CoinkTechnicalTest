using Polly.Retry;

namespace Coink.Microservice.Domain.IResources
{
    public interface IResource
    {
        AsyncRetryPolicy GetRetryPolicy(string method);
    }
}
