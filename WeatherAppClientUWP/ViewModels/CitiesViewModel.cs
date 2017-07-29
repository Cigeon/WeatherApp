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
    public class CitiesViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IWeatherService _weatherService;

        public CitiesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _weatherService = new WeatherService();
            HideAllPopups();
            CreateCommand = new RelayCommand(CreateMenu);
            EditCommand = new RelayCommand(EditMenu);
            DetailsCommand = new RelayCommand(DetailsMenu);
            DeleteCommand = new RelayCommand(DeleteMenu);
            CancelCommand = new RelayCommand(HideAllPopups);
            CreateCityCommand = new RelayCommand(CreateCity);
            SaveCityCommand = new RelayCommand(SaveCity);
            DeleteCityCommand = new RelayCommand(DeleteCity);
            GoBackCommand = new RelayCommand(GoBack);

            PageTitle = "Cities";
            GetCities();
        }

        private void GetCities()
        {
            try
            {
                Cities = _weatherService.GetCitiesAsync().Result;
            }
            catch (Exception)
            {
                HideAllPopups();
                // Show error page
                _navigationService.NavigateTo(nameof(ErrorViewModel));
            }

        }

        private void CreateCity()
        {
            try
            {
                if (NewCity.Text.Equals(String.Empty))
                {
                    NewCity.Value = NewCity.Text;
                    // Send post request
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception)
            {
                HideAllPopups();
                // Show error page
                _navigationService.NavigateTo(nameof(ErrorViewModel));
            }
        }

        private void SaveCity()
        {
            try
            {
                if (NewCity.Text.Equals(String.Empty))
                {
                    NewCity.Value = NewCity.Text;
                    // Send post request
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception)
            {
                HideAllPopups();
                // Show error page
                _navigationService.NavigateTo(nameof(ErrorViewModel));
            }
        }

        private void DeleteCity()
        {
            try
            {
                //Send delete request
            }
            catch (Exception)
            {
                HideAllPopups();
                // Show error page
                _navigationService.NavigateTo(nameof(ErrorViewModel));
            }
        }

        public ObservableCollection<SelectedCity> Cities { get; set; }

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

        private SelectedCity _selectedCity;
        public SelectedCity SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                ShowMenu();
                RaisePropertyChanged(() => SelectedCity);
            }
        }

        private SelectedCity _newCity;
        public SelectedCity NewCity
        {
            get { return _newCity; }
            set
            {
                _newCity = value;
                RaisePropertyChanged(() => NewCity);
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

        private Visibility _createVidible;
        public Visibility CreateIsVisible
        {
            get { return _createVidible; }
            set
            {
                _createVidible = value;
                RaisePropertyChanged(() => CreateIsVisible);
            }
        }

        private Visibility _editVidible;
        public Visibility EditIsVisible
        {
            get { return _editVidible; }
            set
            {
                _editVidible = value;
                RaisePropertyChanged(() => EditIsVisible);
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

        public ICommand CreateCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DetailsCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand CreateCityCommand { get; set; }
        public ICommand SaveCityCommand { get; set; }
        public ICommand DeleteCityCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        private void ShowMenu()
        {
            HideAllPopups();
            ShowMenuIsVisible = Visibility.Visible;
        }

        private void CreateMenu()
        {
            HideAllPopups();
            CreateIsVisible = Visibility.Visible;
        }

        private void EditMenu()
        {
            HideAllPopups();
            EditIsVisible = Visibility.Visible;
        }

        private void DetailsMenu()
        {
            HideAllPopups();
            DetailsIsVisible = Visibility.Visible;
        }

        private void DeleteMenu()
        {
            HideAllPopups();
            _navigationService.NavigateTo(nameof(ErrorViewModel));
            //DeleteIsVisible = true;
        }

        private void HideAllPopups()
        {
            ShowMenuIsVisible = Visibility.Collapsed;
            CreateIsVisible = Visibility.Collapsed;
            EditIsVisible = Visibility.Collapsed;
            DetailsIsVisible = Visibility.Collapsed;
            DeleteIsVisible = Visibility.Collapsed;
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }

        
    }
}
