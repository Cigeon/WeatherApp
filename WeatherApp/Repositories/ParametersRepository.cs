using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Repositories
{
    public class ParametersRepository : IParametersService
    {
        private WeatherContext db;

        public ParametersRepository()
        {
            db = new WeatherContext();
        }


        /// <summary>
        /// Add period for selection
        /// </summary>
        /// <param name="period"></param>
        public void AddParameter(SelectedPeriod period)
        {
            db.SelectedPeriods.Add(period);
            db.SaveChanges();
        }

        /// <summary>
        /// Get list of selected cities for UI
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCities()
        {
            var cities = db.SelectedCities.Select(item => new SelectListItem()
            {
                Text = item.Text,
                Value = item.Value

            }).ToList();

            return cities;
        }

        /// <summary>
        /// Get list of selected periods for UI
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetPeriods()
        {
            var periods = db.SelectedPeriods.Select(item => new SelectListItem()
            {
                Text = item.Text,
                Value = item.Value
            }).ToList();

            return periods;
        }

        /// <summary>
        /// Dispose db context
        /// </summary>
        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}