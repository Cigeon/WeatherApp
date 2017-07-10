using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class Repository : IParametersService
    {
        /// <summary>
        /// Add city for selection to database
        /// </summary>
        /// <param name="city"></param>
        public void AddCity(SelectedCity city)
        {
            using (var db = new WeatherContext())
            {
                db.SelectedCities.Add(city);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Add period for selection to database
        /// </summary>
        /// <param name="period"></param>
        public void AddParameter(SelectedPeriod period)
        {
            using (var db = new WeatherContext())
            {
                db.SelectedPeriods.Add(period);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get list of selected cities for UI
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCities()
        {
            using (var db = new WeatherContext())
            {
                var cities = db.SelectedCities.Select(item => new SelectListItem()
                {
                    Text = item.Text,
                    Value = item.Value

                }).ToList();

                return cities;
            }
        }

        /// <summary>
        /// Get list of selected periods for UI
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetPeriods()
        {
            using (var db = new WeatherContext())
            {
                var periods = db.SelectedPeriods.Select(item => new SelectListItem()
                {
                    Text = item.Text,
                    Value = item.Value
                }).ToList();

                return periods;
            }
        }
    }
}