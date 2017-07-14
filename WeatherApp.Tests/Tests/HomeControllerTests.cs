using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using WeatherApp.Controllers;
using WeatherApp.Models;
using WeatherApp.Tests.Mock.Repositories;

namespace WeatherApp.Tests.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_Return_View_And_Model_Is_Instance_Of_List_WeatherForecast()
        {
            // Arrange 
            var parameters = new MockParametersRepository();
            var controller = new HomeController(null, parameters, null);
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
            var weather = new MockWeatherRepository();
            var parameters = new MockParametersRepository();
            var history = new MockHistoryRepository();
            var controller = new HomeController(weather, parameters, history);
            // Act
            var result = controller.GetWeather(new WeatherRequest()) as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<WeatherForecast>(result.Model);
        }

        [Test]
        public void GetWeather_Redirect_To_Error_View()
        {
            // Arrange 
            var weather = new MockWeatherRepository();
            weather.Error = true;
            var parameters = new MockParametersRepository();
            var history = new MockHistoryRepository();
            var controller = new HomeController(weather, parameters, history);
            // Act
            var result = controller.GetWeather(new WeatherRequest()) as ViewResult;            
            // Assert
            Assert.IsNull(result);
        }
    }
}
