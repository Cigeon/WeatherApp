using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherProvider
    {
        private IWeatherService weatherService;

        public WeatherRequest WeatherRequest { get; set; }

        public WeatherProvider(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        // Get response from weather service
        public ResponseWeatherForecast GetForecast()
        {
            return weatherService.GetWeatherForecast(WeatherRequest);
        }
    }
}