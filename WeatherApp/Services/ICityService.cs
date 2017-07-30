using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface ICityService : IDisposable
    {
        Task<List<SelectedCity>> GetCitiesAsync();
        Task<SelectedCity> GetCityByIdAsync(int? id);
        Task AddCityAsync(SelectedCity city);
        Task EditCityAsync(SelectedCity city);
        Task DeleteCityAsync(int id);
    }
}
