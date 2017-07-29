using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WeatherAppClientUWP.Models;
using WeatherAppClientUWP.Services;
using System;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;

namespace WeatherAppClientUWP.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IWeatherService _weatherService;

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _weatherService = new WeatherService();            
            ManageCitiesCommand = new RelayCommand(GoToManageCities);
            PreviousRequestsCommand = new RelayCommand(GoToPreviousRequest);
            ShowForecastCommand = new RelayCommand(GoToForecast);
            _citiesIsEnabled = true;
            GetParameters();
            City = Cities[0];
            Period = Periods[0];
        }

        private void GetParameters()
        {
            Cities = _weatherService.GetCitiesAsync().Result;
            Periods = _weatherService.GetPeriodsAsync().Result;
        }

        public ObservableCollection<SelectedCity> Cities { get; set; }

        public ObservableCollection<SelectedPeriod> Periods { get; set; }

        private SelectedCity _city;
        public SelectedCity City
        {
            get { return _city; }
            set
            {
                _city = value;
                RaisePropertyChanged(() => City);
            }
        }

        private bool _citiesIsEnabled;
        public bool CitiesIsEnabled
        {
            get { return _citiesIsEnabled; }
            set
            {
                _citiesIsEnabled = value;
                RaisePropertyChanged(() => CitiesIsEnabled);
            }
        }

        private string _customCity;
        public string CustomCity
        {
            get { return _customCity; }
            set
            {
                _customCity = value;
                if (_customCity != "")
                {
                    CitiesIsEnabled = false;
                }
                else
                {
                    CitiesIsEnabled = true;
                }
                RaisePropertyChanged(() => CustomCity);
            }
        }

        private SelectedPeriod _period;
        public SelectedPeriod Period
        {
            get { return _period; }
            set
            {
                _period = value;
                RaisePropertyChanged(() => Period);
            }
        }

        public ICommand ManageCitiesCommand { get; set; }
        public ICommand PreviousRequestsCommand { get; set; }
        public ICommand ShowForecastCommand { get; set; }

        private void GoToManageCities()
        {
            _navigationService.NavigateTo(nameof(CitiesViewModel));
        }

        private void GoToPreviousRequest()
        {
            _navigationService.NavigateTo(nameof(PreviousRequestsViewModel));
        }

        private void GoToForecast()
        {
            var request = new WeatherRequest
            {
                City = City.Value,
                CustomCity = CustomCity,
                Period = Period.Value
            };
          
            MessengerInstance.Send(request, "forecast");
            _navigationService.NavigateTo(nameof(ForecastViewModel));
        }
    }
}
