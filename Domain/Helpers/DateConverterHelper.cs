namespace Coink.Microservice.Domain.Helpers
{
    public static class DateConverterHelper
    {
        public static DateTime GetColombiaDateNow(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneSO())
            );
        }

        private static string GetTimeZoneSO()
        {
            return Environment.OSVersion.Platform.Equals(PlatformID.Win32NT)
                ? "SA Pacific Standard Time"
                : "America/Bogota";
        }
    }
}
