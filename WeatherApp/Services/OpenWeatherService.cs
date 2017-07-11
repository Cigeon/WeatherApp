using Newtonsoft.Json;
using System.Net;
using System.Web.Configuration;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class OpenWeatherService : IWeatherService
    {
        private string token;
        private string uri;
        private string city;

        public OpenWeatherService()
        {
            // Initialize parameters
            Init();            
        }

        /// <summary>
        /// Get parameters from app settings
        /// </summary>
        private void Init()
        {
            token = WebConfigurationManager.AppSettings["OpenWeatherToken"];
            uri = WebConfigurationManager.AppSettings["OpenWeatherUri"];
        }


        /// <summary>
        /// Download weather forecast data from open weather 
        /// </summary>
        /// <param name="weatherRequest"></param>
        /// <returns></returns>
        public WeatherForecast GetWeatherForecast(WeatherRequest weatherRequest)
        {
            // Define city for weather forecast
            city = weatherRequest.City;

            // Check if custom city was typed
            if (weatherRequest.CustomCity != null)
                city = weatherRequest.CustomCity;

            // Uri parameters 
            uri += $"forecast/daily?q={city},uk&units=metric&cnt={weatherRequest.Period}&appid={token}";

            // Get data from open weather
            var json = "";
            using (var client = new WebClient())
            {
                json = client.DownloadString(uri);
            }         

            // Deserialize json
            var data = JsonConvert.DeserializeObject<WeatherForecast>(json);
            data.ReqCity = city;
            data.ReqPeriod = weatherRequest.Period;

            return data;
        }
    }
}