namespace Coink.Microservice.Domain.IResources
{
    public interface IConfigProvider
    {
        #region RetryPolicy
        int GetRetryCount();
        double GetRetrySeconds();
        #endregion

        #region JwtSettings
        string SecretKeyJwtSettings { get; }
        string IssuerJwtSettings { get; }
        string AudienceJwtSettings { get; }
        int TokenExpirationInMinutesJwtSettings { get; }
        #endregion
    }
}
