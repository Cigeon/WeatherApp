using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            //if (ModelState.IsValid)
            //{
            //    ViewBag.Custom = weatherRequest.CustomCity;
            //}

            try
            {
                // Get data from open weather
                if (weatherRequest.Period.Equals("Now"))
                {
                    var weatherResponse = openWeather.GetCurrentWeather(weatherRequest);
                    return View("ViewCurrentWeather", weatherResponse);
                }
                if (weatherRequest.Period.Equals("3 days") || weatherRequest.Period.Equals("7 days"))
                {
                    var weatherResponse = openWeather.GetWeatherForecast(weatherRequest);
                    return View("ViewWeatherForecast", weatherResponse);
                }
            }
            catch (WebException webEx)
            {
                //show custom error page (configured in Web.config)
            }
            catch (Exception ex)
            {
                //show custom error page (configured in Web.config)

            }
            return View("Error");
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