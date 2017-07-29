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
using Windows.UI.Xaml;

namespace WeatherAppClientUWP.ViewModels
{
    public class ForecastViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IWeatherService _weatherService;        

        public ForecastViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _weatherService = new WeatherService();

            GoBackCommand = new RelayCommand(GoBack);

            MessengerInstance.Register<WeatherRequest>(this, "forecast", (req) =>
            {
                Request = req;
            });
        }

        private WeatherRequest _request;
        public WeatherRequest Request
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
            Forecast = _weatherService.GetWeatherForecast(_request).Result;
            PageTitle = $"{Forecast.City.Name} ({Forecast.ReqCity}), wather forecast for {Forecast.ReqPeriod} day(s)";
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
