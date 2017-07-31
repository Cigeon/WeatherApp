using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task AddParameterAsync(SelectedPeriod period)
        {
            db.SelectedPeriods.Add(period);
            db.SaveChanges();
        }

        /// <summary>
        /// Get list of selected cities for UI
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetCitiesAsync()
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
        public async Task<List<SelectListItem>> GetPeriodsAsync()
        {
            var periods = db.SelectedPeriods.Select(item => new SelectListItem()
            {
                Text = item.Text,
                Value = item.Value
            }).ToList();

            return periods;
        }

        /// <summary>
        /// Get list of selected periods for API
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectedPeriod>> GetPeriodsForApiAsync()
        {
            var periods = db.SelectedPeriods.ToList();
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