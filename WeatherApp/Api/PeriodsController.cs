using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Api
{
    public class PeriodsController : ApiController
    {
        private IParametersService parameters;

        public PeriodsController(IParametersService parametersService)
        {
            parameters = parametersService;
        }

        // GET: api/Periods
        public async Task<List<SelectedPeriod>> GetSelectedPeriodsAsync()
        {
            return await parameters.GetPeriodsForApiAsync();
        }
    }
}