using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Tests.Mock.Repositories
{
    public class MockWeatherRepository : IWeatherService
    {
        private Mock<IWeatherService> mock;

        public MockWeatherRepository()
        {
            mock = new Mock<IWeatherService>();
            Setup();
        }

        private void Setup()
        {
            mock.Setup(foo => foo.GetWeatherForecast(It.IsAny<WeatherRequest>())).Returns(new WeatherForecast());
        }

        public WeatherForecast GetWeatherForecast(WeatherRequest weatherRequest)
        {
            return mock.Object.GetWeatherForecast(weatherRequest);
        }
    }
}
