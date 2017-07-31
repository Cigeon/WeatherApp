using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Text;
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
            var result = controller.GetForecastsAsync();
            // Assert
            Assert.IsInstanceOf<List<WeatherForecast>>(result);
        }

        [Test]
        public void GetForecast_When_Right_Id_Return_Specified_Forecast()
        {
            // Arrange
            var id = 1;
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            // Act
            var result = controller.GetForecastAsync(id) as OkNegotiatedContentResult<WeatherForecast>;
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
            var result = controller.GetForecastAsync(id) as NotFoundResult;
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
            var result = controller.PutForecastAsync(forecast.Id, forecast) as StatusCodeResult;
            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.IsTrue(result.StatusCode.Equals(HttpStatusCode.NoContent));
        }

        [Test]
        public void PutForecast_When_Ids_Are_Not_Equal_Return_BadRequest()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            var forecast = GetDummyForecast();
            // Act           
            var result = controller.PutForecastAsync(forecast.Id++, forecast) as BadRequestResult;
            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void PutForecast_When_City_Doesnt_Exist_Return_NotFound()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            var forecast = GetDummyForecast();
            forecast.Id = -1;
            // Act           
            var result = controller.PutForecastAsync(forecast.Id, forecast) as NotFoundResult;
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void PostForecast_When_Model_Ok_Return_Created_Forecast()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            var forecast = GetDummyForecast();
            // Act           
            var result = controller.PostForecastAsync(forecast) as CreatedAtRouteNegotiatedContentResult<WeatherForecast>;
            // Assert
            Assert.IsInstanceOf<CreatedAtRouteNegotiatedContentResult<WeatherForecast>>(result);
            Assert.IsTrue(result.Content.Id == forecast.Id);
        }

        [Test]
        public void PostForecast_When_Model_Is_Null_Return_BadRequest()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            WeatherForecast forecast = null;
            // Act           
            var result = controller.PostForecastAsync(forecast) as BadRequestResult;
            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void DeleteForecast_When_Right_Id_Return_Deleted_Forecast()
        {
            // Arrange
            var id = 1;
            var controller = DependencyResolver.Current.GetService<HistoryController>();
            // Act
            var result = controller.DeleteForecastAsync(id) as OkNegotiatedContentResult<WeatherForecast>;
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
            var result = controller.DeleteForecastAsync(id) as NotFoundResult;
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }


        private WeatherForecast GetDummyForecast()
        {
            var json = "{\"Id\": 1,\"Dt\": '2017-07-17T00:18:34.597',\"City\": {\"Id\": 11,\"Name\": 'Pushcha-Voditsa'," + 
                "\"Coord\": {\"Lon\": 30.5,\"Lat\": 50.45},\"Country\": 'UA',\"Population\": 0},\"Cod\": '200',\"Message\": 0.4889564," +
                "\"Cnt\": 1,\"List\": [{\"Id\": 25,\"Dt\": 1500199200,\"Temp\": {\"Day\": 13.64,\"Min\": 9.79,\"Max\": 13.64," + 
                "\"Night\": 9.79,\"Eve\": 13.64,\"Morn\": 13.64},\"Pressure\": 1018.04,\"Humidity\": 65,\"Weather\": [{" +
                "\"WeatherId\": 25,\"Id\": 0,\"Main\": \"Clear\",\"Description\": 'sky is clear',\"Icon\": '01d',\"DailyForecastId\": 25}]," +
                "\"Speed\": 2.52,\"Deg\": 325,\"Clouds\": 0,\"WeatherForecastId\": 11}],\"ReqCity\": \"Kyiv\",\"ReqPeriod\": '1'}";
            return JsonConvert.DeserializeObject<WeatherForecast>(json);
        }
    }
}
