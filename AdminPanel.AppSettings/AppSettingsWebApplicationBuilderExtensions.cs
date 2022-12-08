using Microsoft.AspNetCore.Builder;

namespace AdminPanel.AppSettings
{
    public static class AppSettingsWebApplicationBuilderExtensions
    {
        

        public static void AppSettingsConfigure(this WebApplicationBuilder builder)
        {
            if(builder == null)
                throw new ArgumentNullException(nameof(builder));

            AppSettingsConfiguration.Create().ConfigurationSet = builder.Configuration;
        }

    }


}

