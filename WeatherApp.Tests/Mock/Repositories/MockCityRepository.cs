﻿using Moq;
using System.Collections.Generic;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Tests.Mock.Repositories
{
    public class MockCityRepository : ICityService
    {
        private Mock<ICityService> mock;

        public MockCityRepository()
        {
            mock = new Mock<ICityService>();
            Setup();
        }

        private void Setup()
        {
            mock.Setup(foo => foo.GetCities()).Returns(new List<SelectedCity>());
            mock.Setup(foo => foo.GetCityById(0)).Returns((SelectedCity)null);
            mock.Setup(foo => foo.GetCityById(1)).Returns(new SelectedCity());
        }

        public List<SelectedCity> GetCities()
        {
            return mock.Object.GetCities();
        }

        public SelectedCity GetCityById(int? id)
        {
            return mock.Object.GetCityById(id);
        }

        public void AddCity(SelectedCity city) { }

        public void DeleteCityAsync(int id) { }

        public void EditCityAsync(SelectedCity city) { }
               
        public void Dispose() {  }

    }
}
