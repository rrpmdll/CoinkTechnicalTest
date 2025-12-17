using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Coink.Microservice.Domain.Exceptions
{
    [Serializable, ExcludeFromCodeCoverage]
    public class RestClientException : Exception
    {
        public HttpResponseMessage HttpResponseMessage { get; }

        public RestClientException()
        {
        }

        public RestClientException(string message) : base(message)
        {
        }

        public RestClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RestClientException(HttpResponseMessage httpResponseMessage)
        {
            HttpResponseMessage = httpResponseMessage;
        }

        public RestClientException(string message, HttpResponseMessage httpResponseMessage) : base(message)
        {
            HttpResponseMessage = httpResponseMessage;
        }

        public RestClientException(string message, Exception innerException, HttpResponseMessage httpResponseMessage) : base(message, innerException)
        {
            HttpResponseMessage = httpResponseMessage;
        }

        protected RestClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
