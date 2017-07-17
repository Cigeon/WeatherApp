using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Repositories
{
    public class CityRepository : ICityService
    {
        private WeatherContext db;

        public CityRepository()
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
            try
            {
                return db.SelectedCities.Find(id);
            }
            catch (InvalidOperationException)
            {
                return null;
            }            
        }

        /// <summary>
        /// Get list of cities
        /// </summary>
        /// <returns></returns>
        public List<SelectedCity> GetCities()
        {
            try
            {
                return db.SelectedCities.ToList();
            }
            catch (InvalidOperationException)
            {
                return new List<SelectedCity>();
            }            
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