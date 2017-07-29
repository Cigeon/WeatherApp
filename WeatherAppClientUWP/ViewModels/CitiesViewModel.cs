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
            CreateCommand = new RelayCommand(CreateCity);
            EditCommand = new RelayCommand(EditCity);
            DetailsCommand = new RelayCommand(DetailsCity);
            DeleteCommand = new RelayCommand(DeleteCity);
            CancelCommand = new RelayCommand(HideAllPopups);
            GoBackCommand = new RelayCommand(GoBack);

            PageTitle = "Cities";
            GetCities();
        }

        private void GetCities()
        {
            Cities = _weatherService.GetCitiesAsync().Result;
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

        private bool _showMenuVidible;
        public bool ShowMenuIsVisible
        {
            get { return _showMenuVidible; }
            set
            {
                _showMenuVidible = value;
                RaisePropertyChanged(() => ShowMenuIsVisible);
            }
        }

        private bool _createVidible;
        public bool CreateIsVisible
        {
            get { return _createVidible; }
            set
            {
                _createVidible = value;
                RaisePropertyChanged(() => CreateIsVisible);
            }
        }

        private bool _editVidible;
        public bool EditIsVisible
        {
            get { return _editVidible; }
            set
            {
                _editVidible = value;
                RaisePropertyChanged(() => EditIsVisible);
            }
        }

        private bool _detailsVidible;
        public bool DetailsIsVisible
        {
            get { return _detailsVidible; }
            set
            {
                _detailsVidible = value;
                RaisePropertyChanged(() => DetailsIsVisible);
            }
        }

        private bool _deleteVidible;
        public bool DeleteIsVisible
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
        public ICommand GoBackCommand { get; set; }

        private void ShowMenu()
        {
            HideAllPopups();
            ShowMenuIsVisible = true;
        }

        private void CreateCity()
        {
            HideAllPopups();
            CreateIsVisible = true;
        }

        private void EditCity()
        {
            HideAllPopups();
            EditIsVisible = true;
        }

        private void DetailsCity()
        {
            HideAllPopups();
            DetailsIsVisible = true;
        }

        private void DeleteCity()
        {
            HideAllPopups();
            DeleteIsVisible = true;
        }

        private void HideAllPopups()
        {
            ShowMenuIsVisible = false;
            CreateIsVisible = false;
            EditIsVisible = false;
            DetailsIsVisible = false;
            DeleteIsVisible = false;
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }

        
    }
}
