using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherAppClientUWP.Models;
using WeatherAppClientUWP.Services;
using Windows.UI.Xaml;

namespace WeatherAppClientUWP.ViewModels
{
    public class PreviousRequestsViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IWeatherService _weatherService;

        public PreviousRequestsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _weatherService = new WeatherService();
            Forecasts = new ObservableCollection<WeatherForecast>();
            HideAllPopups();
            DetailsCommand = new RelayCommand(DetailsMenu);
            DeleteCommand = new RelayCommand(DeleteMenu);
            CancelCommand = new RelayCommand(HideAllPopups);
            DeleteForecastCommand = new RelayCommand(DeleteForecast);
            GoBackCommand = new RelayCommand(GoBack);
            PageTitle = "Previous requests";
            GetForecasts();
        }

        private void GetForecasts()
        {
            try
            {
                var result = _weatherService.GetForecastsAsync().Result;
                Forecasts.Clear();
                foreach (var item in result)
                {
                    Forecasts.Add(item);
                }
            }
            catch (Exception)
            {
                // Show error page
                _navigationService.NavigateTo(nameof(ErrorViewModel));
            }
            finally
            {
                HideAllPopups();
            }
        }

        private void DeleteForecast()
        {
            try
            {
                //Send delete request
                if (SelectedForecast == null)
                    throw new NullReferenceException();
                // Send post request
                _weatherService.DeleteForecast(SelectedForecast.Id);
                // Update city list
                GetForecasts();
            }
            catch (Exception)
            {
                // Show error page
                _navigationService.NavigateTo(nameof(ErrorViewModel));
            }
            finally
            {
                HideAllPopups();
                // Update city list
                GetForecasts();
            }
        }

        public ObservableCollection<WeatherForecast> Forecasts { get; set; }

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

        private WeatherForecast _selectedForecast;
        public WeatherForecast SelectedForecast
        {
            get { return _selectedForecast; }
            set
            {
                _selectedForecast = value;
                ShowMenu();
                RaisePropertyChanged(() => SelectedForecast);
            }
        }

        private Visibility _showMenuVidible;
        public Visibility ShowMenuIsVisible
        {
            get { return _showMenuVidible; }
            set
            {
                _showMenuVidible = value;
                RaisePropertyChanged(() => ShowMenuIsVisible);
            }
        }

        private Visibility _detailsVidible;
        public Visibility DetailsIsVisible
        {
            get { return _detailsVidible; }
            set
            {
                _detailsVidible = value;
                RaisePropertyChanged(() => DetailsIsVisible);
            }
        }

        private Visibility _deleteVidible;
        public Visibility DeleteIsVisible
        {
            get { return _deleteVidible; }
            set
            {
                _deleteVidible = value;
                RaisePropertyChanged(() => DeleteIsVisible);
            }
        }

        public ICommand DetailsCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteForecastCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        private void ShowMenu()
        {
            HideAllPopups();
            ShowMenuIsVisible = Visibility.Visible;
        }

        private void DetailsMenu()
        {
            HideAllPopups();
            MessengerInstance.Send(SelectedForecast.Id, "histForecast");
            _navigationService.NavigateTo(nameof(HistoryForecastViewModel));
        }

        private void DeleteMenu()
        {
            HideAllPopups();
            DeleteIsVisible = Visibility.Visible;
        }

        private void HideAllPopups()
        {
            ShowMenuIsVisible = Visibility.Collapsed;
            DetailsIsVisible = Visibility.Collapsed;
            DeleteIsVisible = Visibility.Collapsed;
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }

    }
}
