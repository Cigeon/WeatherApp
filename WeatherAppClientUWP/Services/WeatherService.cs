using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherAppClientUWP.Models;

namespace WeatherAppClientUWP.Services
{
    public class WeatherService : IWeatherService
    {
        private const string apiUri = "http://localhost:50560/";

        public WeatherService()
        {

        }
        /// <summary>
        /// Get list of cities async
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<SelectedCity>> GetCitiesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Cities");
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ObservableCollection<SelectedCity>>(jsonString);
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
        /// <summary>
        /// Get list of poriods async
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<SelectedPeriod>> GetPeriodsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Periods");
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ObservableCollection<SelectedPeriod>>(jsonString);
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }

        public async Task<WeatherForecast> GetWeatherForecast(WeatherRequest weatherRequest)
        {
            using (var client = new HttpClient())
            {
                // Define city for weather forecast
                var city = weatherRequest.City;
                // Check if custom city was typed
                if (weatherRequest.CustomCity != null)
                    city = weatherRequest.CustomCity;

                client.BaseAddress = new Uri(apiUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"api/Weather/{city}/{weatherRequest.Period}").ConfigureAwait(false);
                // HttpResponseMessage response = await client.GetAsync("api/Periods");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherForecast>(jsonString);
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}
