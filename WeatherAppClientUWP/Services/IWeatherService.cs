using System.Collections.Generic;
using System.Collections.ObjectModel;
using WeatherAppClientUWP.Models;

namespace WeatherAppClientUWP.Services
{
    public interface IWeatherService
    {
        ObservableCollection<SelectedCity> GetCities();
        ObservableCollection<SelectedPeriod> GetPeriods();
    }
}
