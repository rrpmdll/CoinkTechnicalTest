using System.Diagnostics.CodeAnalysis;
using Coink.Microservice.Domain.Exceptions;

namespace Coink.Microservice.Domain.Helpers
{
    public static class ValidatorHelper
    {
        public static void ValidateNullObject<T>([NotNull] this T obj, string message)
            where T : class
        {
            if (obj is null)
            {
                throw new ValidationException(message);
            }
        }
    }
}
