﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using WeatherApp.Controllers;
using WeatherApp.Models;

namespace WeatherApp.Tests.Tests
{
    [TestFixture]
    public class CityControllerTests
    {
        [Test]
        public void Index_Model_Is_Instance_Of_Collection_Of_SelectedCity()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CityController>();
            // Act
            var result = controller.Index() as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<IEnumerable<SelectedCity>>(result.Model);
        }

        [Test]
        public void Details_When_Id_Null_Return_BadRequest_400()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CityController>();
            // Act
            var result = controller.Details(null) as HttpStatusCodeResult;
            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public void Details_When_Id_Not_Found_Return_HttpNotFound()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CityController>();
            // Act
            var result = controller.Details(0) as HttpNotFoundResult;
            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void Details_When_Id_Found_Return_View()
        {
            // Arrange
            var controller = DependencyResolver.Current.GetService<CityController>();
            // Act
            var result = controller.Details(1) as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<SelectedCity>(result.Model);
        }

    }
}
