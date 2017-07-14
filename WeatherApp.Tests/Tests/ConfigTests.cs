using NUnit.Framework;
using WeatherApp.Tests.Tools;

namespace WeatherApp.Tests.Tests
{
    // The file Web.config is copied from WeatherApp project to WeatherApp.Test project to folder "Sandbox"
    // by command - xcopy "$(SolutionDir)WeatherApp\Web.config" "$(ProjectDir)Sandbox\" /y
    // which configured in build events of WeatherApp.Test project

    [TestFixture]
    public class ConfigTests
    {
        [Test]
        public void Config_ConnectionString_Exist()
        {
            // Arrange
            var connName = "DbConnection";
            var config = new TestConfig();
            // Act
            var result = config.GetConnectionString(connName);
            // Assert
            Assert.AreEqual("data source=(localdb)\\MSSQLLocalDB;Initial Catalog=WeatherDb.mdf;Integrated Security=True", result);
        }

        [Test]
        public void Config_OpenWeatherUri_Exist()
        {
            // Arrange
            var config = new TestConfig();
            // Act
            var result = config.OpenWeatherUri;
            // Assert
            Assert.AreEqual("http://api.openweathermap.org/data/2.5/", result);
        }

        [Test]
        public void Config_OpenWeatherToken_Exist()
        {
            // Arrange
            var config = new TestConfig();
            // Act
            var result = config.OpenWeatherToken;
            // Assert
            Assert.AreEqual("c0506ccc9f2277c0e50bb49c9d0d6ec5", result);
        }
    }
}
