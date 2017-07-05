using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private HomeService homeService;
        private OpenWeatherService openWeather;

        public HomeController()
        {
            homeService = new HomeService();
            openWeather = new OpenWeatherService();
        }

        /// <summary>
        /// Get data and load to the view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {            
            InitForm();
            var weatherRequest = new WeatherRequest();
            return View(weatherRequest);
        }

        /// <summary>
        /// Get data from open weather
        /// </summary>
        /// <param name="weatherRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetWeather(WeatherRequest weatherRequest)
        {
            //
            var weatherResponse = openWeather.Download(weatherRequest);
            return Content(weatherResponse);
        }

        /// <summary>
        /// Initialize controls
        /// </summary>
        private void InitForm()
        {
            ViewBag.Cities = homeService.GetCities();
            ViewBag.Periods = homeService.GetPeriods();
        }
    }
}