using Ninject;
using NUnit.Framework;
using System.Web.Mvc;
using WeatherApp.Services;
using WeatherApp.Tests.Mock.Repositories;

namespace WeatherApp.Tests.Tests
{
    [SetUpFixture]
    public class UnitTestSetupFixture
    {
        public UnitTestSetupFixture()
        {

        }

        [OneTimeSetUp]
        public void Setup()
        {
            InitKernel();
        }

        protected virtual IKernel InitKernel()
        {
            var kernel = new StandardKernel();
            DependencyResolver.SetResolver(new Tools.NinjectDependencyResolver(kernel));
            InitRepository(kernel);
            return kernel;
        }

        protected virtual void InitRepository(StandardKernel njectKernel)
        {
            var kernel = njectKernel;
            kernel.Bind<IParametersService>().To<MockParametersRepository>();
            kernel.Bind<IWeatherService>().To<MockWeatherRepository>();
            kernel.Bind<ICityService>().To<MockCityRepository>();
            kernel.Bind<IHistoryService>().To<MockHistoryRepository>();            
        }
    }

}
