using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using System.Web.Mvc;
using WeatherApp.Api;
using WeatherApp.Models;

namespace WeatherApp.Tests.Tests
{
    [TestFixture]
    public class WebApiHistoryControllerTests
    {
        [Test]
        public void GetForecasts_Return_Collection_Of_Forecasts()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            // Act
            var result = controller.GetForecasts();
            // Assert
            Assert.IsInstanceOf<List<WeatherForecast>>(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetForecast_When_Right_Id_Return_Specified_Forecast()
        {
            // Arrange
            var id = 1;
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            // Act
            var result = controller.GetForecast(id) as OkNegotiatedContentResult<WeatherForecast>;
            // Assert
            Assert.IsInstanceOf<OkNegotiatedContentResult<SelectedCity>>(result);
            Assert.IsTrue(result.Content.Id == id);
        }

        [Test]
        public void GetForecast_When_Wrong_Id_Return_NotFound()
        {
            // Arrange
            var id = 100;  // doesn't exist id
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            // Act
            var result = controller.GetForecast(id) as NotFoundResult;
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void PutForecast_When_Model_Ok_Return_204_NoContent()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            var forecast = new WeatherForecast
            {
                Id = 1
            };
            // Act           
            var result = controller.PutForecast(forecast.Id, forecast) as StatusCodeResult;
            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.IsTrue(result.StatusCode.Equals(HttpStatusCode.NoContent));
        }

        [Test]
        public void PutForecast_When_Ids_Are_Not_Equal_Return_BadRequest()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            var forecast = new WeatherForecast
            {
                Id = 1
            };
            // Act           
            var result = controller.PutForecast(forecast.Id++, forecast) as BadRequestResult;
            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void PutForecast_When_City_Doesnt_Exist_Return_NotFound()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            var forecast = new WeatherForecast
            {
                Id = 100       // doesn't exist
            };
            // Act           
            var result = controller.PutForecast(forecast.Id, forecast) as NotFoundResult;
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void PostForecast_When_Model_Ok_Return_Created_Forecast()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            var forecast = new WeatherForecast
            {
                Id = 10
            };
            // Act           
            var result = controller.PostForecast(forecast) as CreatedAtRouteNegotiatedContentResult<SelectedCity>;
            // Assert
            Assert.IsInstanceOf<CreatedAtRouteNegotiatedContentResult<SelectedCity>>(result);
            Assert.IsTrue(result.Content.Id == forecast.Id);
        }

        [Test]
        public void PostForecast_When_Model_Is_Null_Return_BadRequest()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            WeatherForecast forecast = null;
            // Act           
            var result = controller.PostForecast(forecast) as BadRequestResult;
            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void DeleteForecast_When_Right_Id_Return_Deleted_Forecast()
        {
            // Arrange
            var id = 5;
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            // Act
            var result = controller.DeleteForecast(id) as OkNegotiatedContentResult<WeatherForecast>;
            // Assert
            Assert.IsInstanceOf<OkNegotiatedContentResult<WeatherForecast>>(result);
            Assert.IsTrue(result.Content.Id == id);
        }

        [Test]
        public void DeleteForecast_When_Wrong_Id_Return_NotFound()
        {
            // Arrange
            var id = 100;  // doesn't exist id
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            // Act
            var result = controller.DeleteForecast(id) as NotFoundResult;
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
