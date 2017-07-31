using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IHistoryService : IDisposable
    {
        Task<List<WeatherForecast>> GetForecastsAsync();
        Task<WeatherForecast> GetForecastByIdAsync(int? id);
        Task SaveForecastAsync(WeatherForecast forecast);
        Task EditForecastAsync(WeatherForecast forecast);
        Task DeleteForecastAsync(int id);
    }
}
