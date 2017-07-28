using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WeatherAppClientUWP.Models;
using WeatherAppClientUWP.Services;
using System;

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
            Cities = _weatherService.GetCities();
            Periods = _weatherService.GetPeriods();
            ManageCitiesCommand = new RelayCommand(GoToManageCities);
            PreviousRequestsCommand = new RelayCommand(GoToPreviousRequest);
            ShowForecastCommand = new RelayCommand(GoToForecast);
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

        public ICommand ManageCitiesCommand { get; set; }
        public ICommand PreviousRequestsCommand { get; set; }
        public ICommand ShowForecastCommand { get; set; }

        private void GoToManageCities()
        {
            _navigationService.NavigateTo(nameof(ManageCitiesViewModel));
        }

        private void GoToPreviousRequest()
        {
            _navigationService.NavigateTo(nameof(PreviousRequestsViewModel));
        }

        private void GoToForecast()
        {
            _navigationService.NavigateTo(nameof(ForecastViewModel));
        }
    }
}
