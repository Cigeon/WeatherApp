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
            //SimpleIoc.Default.Register<StudentViewModel>();

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
        // Gets the Student view model.
        // </summary>
        // <value>
        // The Student view model.
        // </value>
        //public StudentViewModel StudentVMInstance
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<StudentViewModel>();
        //    }
        //}

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
