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
        /// Download current weather data from open weather 
        /// </summary>
        /// <param name="weatherRequest"></param>
        /// <returns></returns>
        public ResponseCurrentWeather GetCurrentWeather(WeatherRequest weatherRequest)
        {
            // Define city for weather forecast
            city = weatherRequest.City;

            // Check if custom city was typed
            if (weatherRequest.CustomCity != null)
                city = weatherRequest.CustomCity;

            // Uri paramers for current wather data
            parameters += "weather";

            // Set city parameter
            parameters += "?q=";
            parameters += city;
            parameters += ",uk";
            parameters += "&units=metric";

            // Set token
            parameters += "&appid=";
            parameters += token;

            // Add parameters to uri
            uri += parameters;

            // Get data from open weather
            var json = "";
            using (var client = new WebClient())
            {
                json = client.DownloadString(uri);
            }

            // Deserialize json
            var data = JsonConvert.DeserializeObject<ResponseCurrentWeather>(json);
            data.reqCity = city;
            data.reqPeriod = weatherRequest.Period;
            //data.req = weatherRequest;
            return data;
        }

        /// <summary>
        /// Download weather forecast data from open weather 
        /// </summary>
        /// <param name="weatherRequest"></param>
        /// <returns></returns>
        public ResponseWeatherForecast GetWeatherForecast(WeatherRequest weatherRequest)
        {
            // Define city for weather forecast
            city = weatherRequest.City;

            // Check if custom city was typed
            if (weatherRequest.CustomCity != null)
                city = weatherRequest.CustomCity;

            // Uri parameters for 3 days / 7 days forecast
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
            var json = "";
            using (var client = new WebClient())
            {
                json = client.DownloadString(uri);
            }         

            // Deserialize json
            var data = JsonConvert.DeserializeObject<ResponseWeatherForecast>(json);
            data.reqCity = city;
            data.reqPeriod = weatherRequest.Period;
            //data.req = weatherRequest;

            return data;
        }
    }
}