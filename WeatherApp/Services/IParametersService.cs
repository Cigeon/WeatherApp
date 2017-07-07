using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WeatherApp.Services
{
    public interface IParametersService
    {
        List<SelectListItem> GetCities();
        List<SelectListItem> GetPeriods();
    }
}
