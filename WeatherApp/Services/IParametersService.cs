using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IParametersService : IDisposable
    {
        Task AddParameterAsync(SelectedPeriod period);
        Task<List<SelectListItem>> GetCitiesAsync();
        Task<List<SelectListItem>> GetPeriodsAsync();
        Task<List<SelectedPeriod>> GetPeriodsForApiAsync();
    }
}
