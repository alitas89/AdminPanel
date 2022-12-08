using Microsoft.Extensions.Configuration;

namespace AdminPanel.AppSettings
{
    public class AppSettingsConfiguration
    {
        private static AppSettingsConfiguration? appConfiguration;
        private static readonly object lockObject = new object();

        private ConfigurationManager? configuration;

        public ConfigurationManager Configuration { 
            get { 
                if(configuration == null)
                    throw new ArgumentNullException(nameof(ConfigurationManager));
                
                return configuration; } 
        }

        internal ConfigurationManager ConfigurationSet
        {
            set {
                if(value==null)
                    throw new ArgumentNullException(nameof(ConfigurationManager));

                configuration = value;
            }
        }

        private AppSettingsConfiguration()
        {

        }

        public static AppSettingsConfiguration Create()
        {
            if(appConfiguration == null)
            {
                lock (lockObject)
                {
                    appConfiguration ??= new AppSettingsConfiguration();
                }
            }

            return appConfiguration;
        }
    }
}
