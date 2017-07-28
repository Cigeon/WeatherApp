using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using WeatherAppClientUWP.Models;
using WeatherAppClientUWP.Services;

namespace WeatherAppClientUWP.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private IWeatherService weatherService;

        public HomeViewModel(INavigationService navigationService)
        {
            weatherService = new WeatherService();
            Cities = weatherService.GetCities();
            Periods = weatherService.GetPeriods();
            CustomCity = "Vinnitsa";
        }

        public ObservableCollection<SelectedCity> Cities { get; set; }

        public ObservableCollection<SelectedPeriod> Periods { get; set; }

        private string customCity;
        public string CustomCity
        {
            get { return customCity; }
            set
            {
                customCity = value;
                RaisePropertyChanged(() => Title);
            }
        }

    }
}
