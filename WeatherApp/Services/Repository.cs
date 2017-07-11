using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class Repository : IParametersService, ICityService, IHistoryService, IDisposable
    {
        private WeatherContext db;

        public Repository()
        {
            db = new WeatherContext();
        }

        /// <summary>
        /// Add city for selection
        /// </summary>
        /// <param name="city"></param>
        public void AddCity(SelectedCity city)
        {
             // Copy city name to value
             var c = city;
             c.Value = city.Text;

             db.SelectedCities.Add(c);
             db.SaveChanges();
        }

        /// <summary>
        /// Edit city and save it to database
        /// </summary>
        /// <param name="city"></param>
        public void EditCity(SelectedCity city)
        {
             // Copy city name to value
             var c = city;
             c.Value = city.Text;

             db.Entry(c).State = EntityState.Modified;
             db.SaveChanges();           
        }

        /// <summary>
        /// Delete city from database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCity(int id)
        {
             SelectedCity selectedCity = GetCityById(id);
             db.SelectedCities.Attach(selectedCity);
             db.SelectedCities.Remove(selectedCity);
             db.SaveChanges();
        }

        /// <summary>
        /// Get city entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SelectedCity GetCityById(int? id)
        {
            if (id == null) return null;
            return db.SelectedCities.Find(id);
        }

        /// <summary>
        /// Get list of cities
        /// </summary>
        /// <returns></returns>
        public List<SelectedCity> GetCitiesList()
        {
             return db.SelectedCities.ToList();
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
        /// Add period for selection
        /// </summary>
        /// <param name="period"></param>
        public void AddParameter(SelectedPeriod period)
        {
             db.SelectedPeriods.Add(period);
             db.SaveChanges();
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
        /// Get list of forecasts
        /// </summary>
        /// <returns></returns>
        public List<WeatherForecast> GetForecasts()
        {
            return db.WeatherForecasts.ToList();
        }

        /// <summary>
        /// Get forecast by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WeatherForecast GetForecastById(int? id)
        {
            return db.WeatherForecasts.Include(i => i.City)
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