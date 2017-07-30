using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherAppClientUWP.Models;
using WeatherAppClientUWP.Services;

namespace WeatherAppClientUWP.ViewModels
{
    public class HistoryForecastViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IWeatherService _weatherService;

        public HistoryForecastViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _weatherService = new WeatherService();

            GoBackCommand = new RelayCommand(GoBack);

            MessengerInstance.Register<int>(this, "histForecast", (req) =>
            {
                Request = req;
            });
        }

        private int _request;
        public int Request
        {
            get { return _request; }
            set
            {
                _request = value;
                GetForecast();
                RaisePropertyChanged(() => Request);
            }
        }

        private void GetForecast()
        {
            try
            {
                Forecast = _weatherService.GetForecastByIdAsync(_request).Result;
                PageTitle = $"{Forecast.Dt} {Forecast.City.Name} ({Forecast.ReqCity}), wather forecast for {Forecast.ReqPeriod} day(s)";
            }
            catch (Exception)
            {
                // Show error page
                _navigationService.NavigateTo(nameof(ErrorViewModel));
            }
            
        }

        private WeatherForecast _forecast;
        public WeatherForecast Forecast
        {
            get { return _forecast; }
            set
            {
                _forecast = value;
                RaisePropertyChanged(() => Forecast);
            }
        }

        private string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                RaisePropertyChanged(() => PageTitle);
            }
        }

        public ICommand GoBackCommand { get; set; }

        private void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
