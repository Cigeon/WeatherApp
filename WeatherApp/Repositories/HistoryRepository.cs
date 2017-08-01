using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Repositories
{
    public class HistoryRepository : IHistoryService
    {
        private WeatherContext db;

        public HistoryRepository()
        {
            db = new WeatherContext();
        }

        /// <summary>
        /// Get list of forecasts
        /// </summary>
        /// <returns></returns>
        public async Task<List<WeatherForecast>> GetForecastsAsync()
        {
            try
            {
                return db.WeatherForecasts.Include(ei => ei.City)
                                      .Include(i => i.List.Select(s => s.Weather))
                                      .ToList();
            }
            catch (InvalidOperationException)
            {
                return new List<WeatherForecast>();
            }

        }

        /// <summary>
        /// Get forecast by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WeatherForecast> GetForecastByIdAsync(int? id)
        {
            try
            {
                return db.WeatherForecasts.Include(ei => ei.City)
                                      .Include(i => i.List.Select(s => s.Weather))
                                      .Single(i => i.Id == id);

            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Save forecast to database
        /// </summary>
        /// <param name="forecast"></param>
        public async Task SaveForecastAsync(WeatherForecast forecast)
        {
            // Add timestamp to forecast
            forecast.Dt = DateTime.Now;

            db.WeatherForecasts.Add(forecast);
            db.SaveChanges();
        }

        /// <summary>
        /// Edit forecast and save it to database
        /// </summary>
        /// <param name="forecast"></param>
        public async Task EditForecastAsync(WeatherForecast forecast)
        {
            db.Entry(forecast).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Delete forecast from database
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteForecastAsync(int id)
        {
            var forecast = db.WeatherForecasts
                                .Include(ei => ei.City)
                                .Include(i => i.List.Select(s => s.Weather))
                                .Single(i => i.Id == id);

            db.Cities.Remove(forecast.City);
            foreach (var item in forecast.List)
            {
                db.Weathers.RemoveRange(item.Weather);
            }
            db.DailyForecasts.RemoveRange(forecast.List);
            db.WeatherForecasts.Remove(forecast);            
            
            db.SaveChanges();
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