using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherApp.Services
{
    public class ParametersProvider
    {
        private IParametersService paramService;

        public ParametersProvider(IParametersService paramService)
        {
            this.paramService = paramService;
        }

        public List<SelectListItem> GetCities()
        {
            return paramService.GetCities();
        }

        public List<SelectListItem> GetPeriods()
        {
            return paramService.GetPeriods();
        }
    }
}