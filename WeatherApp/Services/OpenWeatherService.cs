using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        public async Task<WeatherForecast> GetWeatherForecastAsync(WeatherRequest weatherRequest)
        {
            // Define city for weather forecast
            city = weatherRequest.City;

            // Check if custom city was typed
            if (weatherRequest.CustomCity != null)
                city = weatherRequest.CustomCity;

            // Uri parameters 
            token = WebConfigurationManager.AppSettings["OpenWeatherToken"];
            uri = WebConfigurationManager.AppSettings["OpenWeatherUri"];
            var param = $"forecast/daily?q={city},uk&units=metric&cnt={weatherRequest.Period}&appid={token}";

            // Get data from open weather
            var json = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(param).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();                    
                }
                else
                {
                    throw new HttpRequestException();
                }
            }

            // Deserialize json
            var data = JsonConvert.DeserializeObject<WeatherForecast>(json);
            data.Dt = DateTime.Now;
            data.ReqCity = city;
            data.ReqPeriod = weatherRequest.Period;

            return data;
        }
    }
}