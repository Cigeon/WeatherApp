using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Infrastructure;

namespace WeatherApp.Tests.Setup
{
    public class UnitTestSetupFixture
    {
        [SetUp]
        public virtual void Setup()
        {
            InitKernel();
        }
        protected virtual IKernel InitKernel()

        {
            var kernel = new StandardKernel();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            //InitRepository(kernel); 
            return kernel;
        }
    }
}
