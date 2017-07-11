using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel ninjectKernel)
        {
            kernel = ninjectKernel;
            kernel.Bind<IWeatherService>().To<OpenWeatherService>();                        
            kernel.Bind<IParametersService>().To<Repository>();
            kernel.Bind<ICityService>().To<Repository>();
            kernel.Bind<IHistoryService>().To<Repository>();                

        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

    }
}