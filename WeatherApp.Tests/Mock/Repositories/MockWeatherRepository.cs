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

        public bool Error { get; set; }

        public MockWeatherRepository()
        {
            mock = new Mock<IWeatherService>();            
        }
        public WeatherForecast GetWeatherForecast(WeatherRequest weatherRequest)
        {
            if (Error)
            {
                mock.Setup(foo => foo.GetWeatherForecast(It.IsAny<WeatherRequest>())).Throws(new WebException());
            }
            else
            {
                mock.Setup(foo => foo.GetWeatherForecast(It.IsAny<WeatherRequest>())).Returns(new WeatherForecast());
            }
            return mock.Object.GetWeatherForecast(weatherRequest);
        }
    }
}
