using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IHistoryService
    {
        List<WeatherForecast> GetForecasts();
        WeatherForecast GetForecastById(int? id);
        void SaveForecast(WeatherForecast forecast);
        void DeleteForecast(int id);
        void Dispose();
    }
}
