using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IParametersService : IDisposable
    {
        void AddParameter(SelectedPeriod period);
        List<SelectListItem> GetCities();
        List<SelectListItem> GetPeriods();
        List<SelectedPeriod> GetPeriodsForApi();
    }
}
