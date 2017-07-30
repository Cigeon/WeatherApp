using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using WeatherApp.Api;
using WeatherApp.Models;

namespace WeatherApp.Tests.Tests
{
    [TestFixture]
    public class WebApiCitiesControllerTests
    {
        [Test]
        public void GetCities_Return_Collection_Of_Cities()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            // Act
            var result = controller.GetCities();
            // Assert
            Assert.IsInstanceOf<List<SelectedCity>>(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetCity_When_Right_Id_Return_Specified_City()
        {
            // Arrange
            var id = 1;
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            // Act
            var result = controller.GetCityAsync(id) as OkNegotiatedContentResult<SelectedCity>;
            // Assert
            Assert.IsInstanceOf<OkNegotiatedContentResult<SelectedCity>>(result);
            Assert.IsTrue(result.Content.Id == id);
        }

        [Test]
        public void GetCity_When_Wrong_Id_Return_NotFound()
        {
            // Arrange
            var id = 100;  // doesn't exist id
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            // Act
            var result = controller.GetCityAsync(id) as NotFoundResult;
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void PutCity_When_Model_Ok_Return_204_NoContent()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            var city = new SelectedCity
            {
                Id = 1,
                Text = "Kyiv",
                Value = "Kyiv"
            };
            // Act           
            var result = controller.PutCityAsync(city.Id, city) as StatusCodeResult;
            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            Assert.IsTrue(result.StatusCode.Equals(HttpStatusCode.NoContent));
        }

        [Test]
        public void PutCity_When_Ids_Are_Not_Equal_Return_BadRequest()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            var city = new SelectedCity
            {
                Id = 1,
                Text = "Kyiv",
                Value = "Kyiv"
            };
            // Act           
            var result = controller.PutCityAsync(city.Id++, city) as BadRequestResult;
            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void PutCity_When_City_Doesnt_Exist_Return_NotFound()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            var city = new SelectedCity
            {
                Id = 100,       // doesn't exist
                Text = "Kyiv",
                Value = "Kyiv"
            };
            // Act           
            var result = controller.PutCityAsync(city.Id, city) as NotFoundResult;
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void PostCity_When_Model_Ok_Return_Created_City()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            var city = new SelectedCity
            {
                Id = 10,
                Text = "Vinnitsya",
                Value = "Vinnitsya"
            };
            // Act           
            var result = controller.PostCityAsync(city) as CreatedAtRouteNegotiatedContentResult<SelectedCity>;
            // Assert
            Assert.IsInstanceOf<CreatedAtRouteNegotiatedContentResult<SelectedCity>>(result);
            Assert.IsTrue(result.Content.Id == city.Id);
        }

        [Test]
        public void PostCity_When_Model_Is_Null_Return_BadRequest()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            SelectedCity city = null;
            // Act           
            var result = controller.PostCityAsync(city) as BadRequestResult;
            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void DeleteCity_When_Right_Id_Return_Deleted_City()
        {
            // Arrange
            var id = 5;
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            // Act
            var result = controller.DeleteCityAsync(id) as OkNegotiatedContentResult<SelectedCity>;
            // Assert
            Assert.IsInstanceOf<OkNegotiatedContentResult<SelectedCity>>(result);
            Assert.IsTrue(result.Content.Id == id);
        }

        [Test]
        public void DeleteCity_When_Wrong_Id_Return_NotFound()
        {
            // Arrange
            var id = 100;  // doesn't exist id
            var controller = DependencyResolver.Current.GetService<CitiesController>();
            // Act
            var result = controller.DeleteCityAsync(id) as NotFoundResult;
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
