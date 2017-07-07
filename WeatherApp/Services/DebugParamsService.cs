using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherApp.Services
{
    public class DebugParamsService : IParametersService
    {
        public DebugParamsService()
        {

        }

        /// <summary>
        /// Get the cities list
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCities()
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            cities.Add(new SelectListItem() { Text = "Poltava", Value = "Poltava" });
            cities.Add(new SelectListItem() { Text = "Vinnitsa", Value = "Vinnitsa" });
            cities.Add(new SelectListItem() { Text = "Chernihiv", Value = "Chernihiv" });
            cities.Add(new SelectListItem() { Text = "Luhansk", Value = "Luhansk" });
            cities.Add(new SelectListItem() { Text = "Ternopil", Value = "Ternopil" });
            return cities;
        }
        /// <summary>
        /// Get the periods list
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetPeriods()
        {
            List<SelectListItem> periods = new List<SelectListItem>();
            periods.Add(new SelectListItem() { Text = "For 3 days", Value = "3" });
            periods.Add(new SelectListItem() { Text = "For 10 days", Value = "10" });
            periods.Add(new SelectListItem() { Text = "For 14 days", Value = "14" });
            return periods;
        }

    }

}