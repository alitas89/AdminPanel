using Microsoft.Extensions.Configuration;

namespace AdminPanel.AppSettings
{
    public static class AppSettingsConfigurationExtensions
    {
        public static string GetSQLCompatibilityString(this IConfiguration configuration, string name)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return configuration.GetSection("SQLCompatibility")?[name];
        }
    }
}
