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

            ProgressRingIsVisible = Visibility.Visible;

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
                Forecast = _weatherService.GetWeatherForecast(_request).Result;
                //ProgressRingIsVisible = Visibility.Collapsed;
                RaisePropertyChanged(() => Request);
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

        private Visibility _prVisible;
        public Visibility ProgressRingIsVisible
        {
            get { return _prVisible; }
            set
            {
                _prVisible = value;
                RaisePropertyChanged(() => ProgressRingIsVisible);
            }
        }

        public ICommand GoBackCommand { get; set; }

        private void goBack()
        {
            _navigationService.GoBack();
        }
    }
}
