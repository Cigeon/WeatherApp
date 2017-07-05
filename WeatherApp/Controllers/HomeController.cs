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

        public HomeController()
        {
            homeService = new HomeService();
        }

        /// <summary>
        /// Get the data and load to the view
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
        /// Save the data From View by posting method
        /// </summary>
        /// <param name="weatherRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(WeatherRequest wr)
        {
            //save dato to database
            return Content("Request success...");
        }

        private void InitForm()
        {
            ViewBag.Cities = homeService.GetCities();
            ViewBag.Periods = homeService.GetPeriods();
        }
    }
}