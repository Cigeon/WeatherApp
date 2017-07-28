using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppClientUWP.Models;

namespace WeatherAppClientUWP.Services
{
    public class WeatherService : IWeatherService
    {
        public ObservableCollection<SelectedCity> GetCities()
        {
            return 
                new ObservableCollection<SelectedCity>
                {
                    new SelectedCity
                    {
                        Text = "Kyiv",
                        Value = "Kyiv"
                    },
                    new SelectedCity
                    {
                        Text = "Lviv",
                        Value = "Lviv"
                    }
                };
        }

        public ObservableCollection<SelectedPeriod> GetPeriods()
        {
            return
                new ObservableCollection<SelectedPeriod>
                {
                    new SelectedPeriod
                    {
                        Text = "Current weather",
                        Value = "1"
                    },
                    new SelectedPeriod
                    {
                        Text = "3 days",
                        Value = "3"
                    }
                };
        }
    }
}
