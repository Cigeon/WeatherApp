using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task AddCityAsync(SelectedCity city)
        {
            // Copy city name to value
            var c = city;
            c.Value = city.Text;

            db.SelectedCities.Add(c);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Edit city and save it to database
        /// </summary>
        /// <param name="city"></param>
        public async Task EditCityAsync(SelectedCity city)
        {
            // Copy city name to value
            var c = city;
            c.Value = city.Text;

            db.Entry(c).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Delete city from database
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteCityAsync(int id)
        {
            SelectedCity selectedCity = await GetCityByIdAsync(id);
            db.SelectedCities.Attach(selectedCity);
            db.SelectedCities.Remove(selectedCity);
            db.SaveChanges();
        }

        /// <summary>
        /// Get city entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SelectedCity> GetCityByIdAsync(int? id)
        {
            if (id == null) return null;
            try
            {
                return await db.SelectedCities.FindAsync(id);
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
        public async Task<List<SelectedCity>> GetCitiesAsync()
        {
            try
            {
                return await db.SelectedCities.ToListAsync();
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