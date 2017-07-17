using Newtonsoft.Json;
using System;
using System.Web.Http;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Api
{
    public class WeatherController : ApiController
    {
        private IWeatherService weatherService;
        private IHistoryService historyService;

        public WeatherController(IWeatherService weather, IHistoryService history)
        {
            weatherService = weather;
            historyService = history;
        }

        // GET: api/Weather
        public WeatherForecast Get()
        {
            return weatherService.GetWeatherForecast(new WeatherRequest());
        }

        // GET: api/Weather/London/1
        [Route("api/Weather/{city}/{period}")]
        public IHttpActionResult Get(string city, string period)
        {
            // Check city parameter
            if (city.Length == 0)
                return BadRequest();

            // Check period parameter
            var days = 0;
            if (!Int32.TryParse(period, out days))
                return BadRequest();
            if (days != 1 && days != 3 && days != 7)
                return BadRequest();

            // Create weather request
            var request = new WeatherRequest
            {
                CustomCity = city,
                Period = period
            };

            // Get forecast
            var forecast = weatherService.GetWeatherForecast(request);

            if (forecast == null)
                return NotFound();

            // Save forecast to history
            try
            {
                historyService.SaveForecast(forecast);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return Ok(forecast);
        }
    }
}
