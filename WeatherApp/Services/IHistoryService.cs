using System;
using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IHistoryService : IDisposable
    {
        List<WeatherForecast> GetForecasts();
        WeatherForecast GetForecastById(int? id);
        void SaveForecast(WeatherForecast forecast);
        void EditForecast(WeatherForecast forecast);
        void DeleteForecast(int id);
    }
}
