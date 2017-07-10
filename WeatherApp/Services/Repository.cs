﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class Repository : IParametersService, IDisposable
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
             db.SelectedCities.Add(city);
             db.SaveChanges();
        }

        /// <summary>
        /// Edit city and save it to database
        /// </summary>
        /// <param name="city"></param>
        public void EditCity(SelectedCity city)
        {
             db.Entry(city).State = EntityState.Modified;
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