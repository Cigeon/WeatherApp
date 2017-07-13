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
        public void Index_Model_Is_Instance_Of_List_Of_WeatherForecast()
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
    }
}
