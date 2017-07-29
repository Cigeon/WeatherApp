using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WeatherAppClientUWP.Models;

namespace WeatherAppClientUWP.Services
{
    public interface IWeatherService
    {
        Task<ObservableCollection<SelectedCity>> GetCitiesAsync();
        Task<ObservableCollection<SelectedPeriod>> GetPeriodsAsync();
        Task<WeatherForecast> GetWeatherForecast(WeatherRequest weatherRequest);
    }
}
