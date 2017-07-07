using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class HomeService
    {
        public HomeService()
        {

        }

        /// <summary>
        /// Get the cities list
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCities()
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            cities.Add(new SelectListItem() { Text = "Kyiv", Value = "Kyiv" });
            cities.Add(new SelectListItem() { Text = "Lviv", Value = "Lviv" });
            cities.Add(new SelectListItem() { Text = "Kharkiv", Value = "Kharkiv" });
            cities.Add(new SelectListItem() { Text = "Dnipro", Value = "Dnipro" });
            cities.Add(new SelectListItem() { Text = "Odessa", Value = "Odessa" });
            return cities;
        }
        /// <summary>
        /// Get the periods list
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetPeriods()
        {
            List<SelectListItem> periods = new List<SelectListItem>();
            periods.Add(new SelectListItem() { Text = "Current weather", Value = "1" });
            periods.Add(new SelectListItem() { Text = "For 3 days", Value = "3" });
            periods.Add(new SelectListItem() { Text = "For 7 days", Value = "7" });
            return periods;
        }
    }
}