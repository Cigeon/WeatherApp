using System;
using Moq;
using WeatherApp.Services;
using WeatherApp.Models;
using System.Collections.Generic;

namespace WeatherApp.Tests.Mock.Repositories
{
    public class MockHistoryRepository : IHistoryService
    {
        private Mock<IHistoryService> mock;

        public MockHistoryRepository()
        {
            mock = new Mock<IHistoryService>();
            Setup();
        }

        private void Setup()
        {
            mock.Setup(foo => foo.GetForecasts()).Returns(new List<WeatherForecast>());
            mock.Setup(foo => foo.GetForecastById(0)).Returns((WeatherForecast)null);
            mock.Setup(foo => foo.GetForecastById(1)).Returns(new WeatherForecast());
        }

        public List<WeatherForecast> GetForecasts()
        {
            return mock.Object.GetForecasts();
        }

        public WeatherForecast GetForecastById(int? id)
        {
            return mock.Object.GetForecastById(id);
        }

        public void SaveForecast(WeatherForecast forecast) { }

        public void DeleteForecast(int id) { }

        public void Dispose() { }
    }
}
