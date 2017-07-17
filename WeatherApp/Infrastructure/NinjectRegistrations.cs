using Ninject.Modules;
using WeatherApp.Repositories;
using WeatherApp.Services;

namespace WeatherApp.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeatherService>().To<OpenWeatherService>();
            Bind<IParametersService>().To<ParametersRepository>();
            Bind<ICityService>().To<CityRepository>();
            Bind<IHistoryService>().To<HistoryRepository>(); 
        }
    }
}