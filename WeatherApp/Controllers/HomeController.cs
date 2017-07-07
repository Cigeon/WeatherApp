using Ninject;
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
        private IParametersService paramService;
        private IWeatherService weatherService;

        public HomeController(IWeatherService weatherParam, IParametersService param)
        {            
            // Get parameters service from Ninject
            paramService = param;
            // Get weather service from Ninject
            weatherService = weatherParam;
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
            try
            {
                var weatherProvider = new WeatherProvider(weatherService)
                {
                    WeatherRequest = weatherRequest
                };
                //Get data from open weather
                var weatherResponse = weatherProvider.GetForecast();
                return View("ViewWeatherForecast", weatherResponse);
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
            var paramProvider = new ParametersProvider(paramService);
            ViewBag.Cities = paramProvider.GetCities();
            ViewBag.Periods = paramProvider.GetPeriods();
        }
    }
}