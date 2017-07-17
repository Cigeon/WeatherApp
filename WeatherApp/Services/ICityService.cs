using System;
using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface ICityService : IDisposable
    {
        List<SelectedCity> GetCities();
        SelectedCity GetCityById(int? id);
        void AddCity(SelectedCity city);
        void EditCity(SelectedCity city);
        void DeleteCity(int id);
    }
}
