using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Controllers;

namespace WeatherApp.Tests.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {

        [Test]
        public void Index_Return_View_And_Model_Is_Instance_Of_List_WeatherForecast()
        {
            // Arrange 
            var controller = DependencyResolver.Current.GetService<HomeController>();
            // Act
            var result = controller.Index() as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<WeatherRequest>(result.Model);
            Assert.IsInstanceOf<List<SelectListItem>>(result.ViewData["Cities"]);
            Assert.IsInstanceOf<List<SelectListItem>>(result.ViewData["Periods"]);
        }

        [Test]
        public void GetWeather_Return_View_And_Model_Is_Instance_Of_WeatherForecast()
        {
            // Arrange 
            var controller = DependencyResolver.Current.GetService<HomeController>();
            // Act
            var result = controller.GetWeather(new WeatherRequest()) as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<WeatherForecast>(result.Model);
        }
    }
}
