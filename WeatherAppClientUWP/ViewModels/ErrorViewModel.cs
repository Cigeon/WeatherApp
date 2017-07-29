using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherAppClientUWP.ViewModels
{
    public class ErrorViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public ErrorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            PageTitle = "Error!";
            PageDescription = "An error occurred while processing your request";
            GoBackCommand = new RelayCommand(GoBack);
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

        private string _pageDesc;
        public string PageDescription
        {
            get { return _pageDesc; }
            set
            {
                _pageDesc = value;
                RaisePropertyChanged(() => PageDescription);
            }
        }

        public ICommand GoBackCommand { get; set; }


        private void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
