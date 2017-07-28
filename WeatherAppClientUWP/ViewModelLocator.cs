using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using WeatherAppClientUWP.ViewModels;
using WeatherAppClientUWP.Views;

namespace WeatherAppClientUWP
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(HomeViewModel), typeof(HomeView));
            navigationService.Configure(nameof(ManageCitiesViewModel), typeof(ManageCitiesView));
            navigationService.Configure(nameof(PreviousRequestsViewModel), typeof(PreviousRequestsView));
            navigationService.Configure(nameof(ForecastViewModel), typeof(ForecastView));
            //navigationService.Configure(nameof(StudentViewModel), typeof(StudentView));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<ManageCitiesViewModel>();
            SimpleIoc.Default.Register<PreviousRequestsViewModel>();
            SimpleIoc.Default.Register<ForecastViewModel>();

            ServiceLocator.Current.GetInstance<HomeViewModel>();
        }


        // <summary>
        // Gets the Home view model.
        // </summary>
        // <value>
        // The Home view model.
        // </value>
        public HomeViewModel HomeVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        // <summary>
        // Gets the Manage cities view model.
        // </summary>
        // <value>
        // The Manage cities view model.
        // </value>
        public ManageCitiesViewModel ManageCitiesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ManageCitiesViewModel>();
            }
        }

        // <summary>
        // Gets the Previous requests view model.
        // </summary>
        // <value>
        // The Previous requestsview model.
        // </value>
        public PreviousRequestsViewModel PreviousRequestsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PreviousRequestsViewModel>();
            }
        }

        // <summary>
        // Gets the Forecast view model.
        // </summary>
        // <value>
        // The Forecast view model.
        // </value>
        public ForecastViewModel ForecastVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ForecastViewModel>();
            }
        }


        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
