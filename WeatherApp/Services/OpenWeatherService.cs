using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class OpenWeatherService
    {
        private string token;
        private string uri;
        private string parameters;
        private string city;

        public OpenWeatherService()
        {
            // Initialize parameters
            Init();            
        }

        private void Init()
        {
            token = WebConfigurationManager.AppSettings["OpenWeatherToken"];
            uri = WebConfigurationManager.AppSettings["OpenWeatherUri"];
            //parameters = "";
        }

        /// <summary>
        /// Download weather data from open weather 
        /// </summary>
        /// <param name="weatherRequest"></param>
        /// <returns></returns>
        public WeatherResponse Download(WeatherRequest weatherRequest)
        {
            // Define city for weather forecast
            city = weatherRequest.City;

            // Check if custom city was typed
            if (weatherRequest.CustomCity != null)
                city = weatherRequest.CustomCity;

            // Uri paramers for current wather data
            if (weatherRequest.Period.Equals("Now"))
                parameters += "weather";

            // Uri parameters for 3 days / 7 days forecast
            if (weatherRequest.Period.Equals("3 days") || weatherRequest.Period.Equals("7 days"))
                parameters += "forecast/daily";

            // Set city parameter
            parameters += "?q=";
            parameters += city;
            parameters += ",uk";
            parameters += "&units=metric";

            // Set number of days for forecast
            if (weatherRequest.Period.Equals("3 days"))
                parameters += "&cnt=3";
            if (weatherRequest.Period.Equals("7 days"))
                parameters += "&cnt=7";

            // Set token
            parameters += "&appid=";
            parameters += token;

            // Add parameters to uri
            uri += parameters;

            // Get data from open weather
            var client = new WebClient();
            var json = client.DownloadString(uri);

            // Deserialize json
            // current weather
            if (weatherRequest.Period.Equals("Now"))
            {
                var data = JsonConvert.DeserializeObject<ResponseCurrentWeather>(json);
                data.req = weatherRequest;
                return data;
            }
                      
            // weather 3 days / 7 days forecast
            if (weatherRequest.Period.Equals("3 days") || weatherRequest.Period.Equals("7 days"))
            { 
                var data = JsonConvert.DeserializeObject<ResponseWeatherForecast>(json);
                data.req = weatherRequest;
                return data;
            }

            return null;
        }
    }
}