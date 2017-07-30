using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class ParametersService : IParametersService
    {
        public ParametersService()
        {

        }

        /// <summary>
        /// Add period for selection
        /// </summary>
        /// <param name="period"></param>
        public void AddParameter(SelectedPeriod period)
        {
            
        }

        /// <summary>
        /// Get the cities list for UI
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
        /// Get the periods list for UI
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
        /// <summary>
        /// Get the periods list for API
        /// </summary>
        /// <returns></returns>
        public List<SelectedPeriod> GetPeriodsForApi()
        {
            List<SelectedPeriod> periods = new List<SelectedPeriod>();
            periods.Add(new SelectedPeriod() { Text = "Current weather", Value = "1" });
            periods.Add(new SelectedPeriod() { Text = "For 3 days", Value = "3" });
            periods.Add(new SelectedPeriod() { Text = "For 7 days", Value = "7" });
            return periods;
        }

        /// <summary>
        /// Dispose 
        /// </summary>
        public void Dispose()
        {

        }
    }
}