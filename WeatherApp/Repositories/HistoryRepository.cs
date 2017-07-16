using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        public List<WeatherForecast> GetForecasts()
        {
            return db.WeatherForecasts.Include(ei => ei.City)
                                      .Include(i => i.List.Select(s => s.Weather))
                                      .ToList();
        }

        /// <summary>
        /// Get forecast by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WeatherForecast GetForecastById(int? id)
        {
            return db.WeatherForecasts.Include(ei => ei.City)
                                      .Include(i => i.List.Select(s => s.Weather))
                                      .Single(i => i.Id == id);
        }

        /// <summary>
        /// Save forecast to database
        /// </summary>
        /// <param name="forecast"></param>
        public void SaveForecast(WeatherForecast forecast)
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
        public void EditForecast(WeatherForecast forecast)
        {
            db.Entry(forecast).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Delete forecast from database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteForecast(int id)
        {
            var forecast = db.WeatherForecasts
                             .Include(i => i.City)
                             .Include(i => i.List.Select(s => s.Weather))
                             .Single(i => i.Id.Equals(id));

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