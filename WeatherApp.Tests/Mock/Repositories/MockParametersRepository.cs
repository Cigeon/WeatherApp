using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;
using System;

namespace WeatherApp.Tests.Mock.Repositories
{
    public class MockParametersRepository : IParametersService
    {
        private Mock<IParametersService> mock;

        public MockParametersRepository()
        {
            mock = new Mock<IParametersService>();
            mock.Setup(foo => foo.GetCities()).Returns(new List<SelectListItem>());
            mock.Setup(foo => foo.GetPeriods()).Returns(new List<SelectListItem>());
        }

        public List<SelectListItem> GetCities()
        {
            return mock.Object.GetCities();
        }

        public List<SelectListItem> GetPeriods()
        {
            return mock.Object.GetPeriods();
        }

        public void AddParameter(SelectedPeriod period) { }

        public void Dispose() { }

    }
}
