using System;
using System.Net;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private IParametersService paramService;
        private IWeatherService weatherService;
        private IHistoryService historyService;

        public HomeController(IWeatherService weather, IParametersService param, IHistoryService history)
        {            
            // Get services from Ninject
            paramService = param;
            weatherService = weather;
            historyService = history;

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
                // Get forecast from open weather
                var forecast = weatherService.GetWeatherForecastAsync(weatherRequest).Result;
                // Save weather forecast                
                historyService.SaveForecast(forecast);
                
                return View("ViewWeatherForecast", forecast);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        /// <summary>
        /// Initialize controls
        /// </summary>
        private void InitForm()
        {
            ViewBag.Cities = paramService.GetCities();
            ViewBag.Periods = paramService.GetPeriods();
        }
    }
}