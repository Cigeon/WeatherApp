using System.Configuration;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace WeatherApp.Tests.Tools
{
    public class TestConfig 
    {
        private Configuration configuration;
        protected static string Sandbox = "../../Sandbox";

        public TestConfig()
        {
            var currentDir = System.AppDomain.CurrentDomain.BaseDirectory;
            var configPath = new FileInfo(currentDir + Sandbox + "/Web.config").FullName;
            var configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configPath;
            configuration = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
        }

        public string GetConnectionString(string connectionString)
        {
            return configuration.ConnectionStrings.ConnectionStrings[connectionString].ConnectionString;
        }

        public string OpenWeatherUri
        {
            get
            {
                return configuration.AppSettings.Settings["OpenWeatherUri"].Value;
            }
        }

        public string OpenWeatherToken
        {
            get
            {                
                return configuration.AppSettings.Settings["OpenWeatherToken"].Value;
            }
        }
    }
}
