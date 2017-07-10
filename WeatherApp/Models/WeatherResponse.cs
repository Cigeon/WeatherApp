using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public abstract class WeatherResponse
    {
    }

    // Response model for weather forecast
    public class ResponseWeatherForecast
    {
        public int Id { get; set; }
        public City City { get; set; }
        public string Cod { get; set; }
        public double Message { get; set; }
        public int Cnt { get; set; }
        public List<DailyForecast> list { get; set; }
        public string ReqCity { get; set; }
        public string ReqPeriod { get; set; }
    }

    public class DailyForecast
    {
        public int Id { get; set; }
        public int Dt { get; set; }
        public Temp Temp { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public List<Weather> Weather { get; set; }
        public double Speed { get; set; }
        public double Deg { get; set; }
        public double Clouds { get; set; }
        public int? WeatherForecastId { get; set; }
    }

    public class Weather
    {
        public int WeatherId { get; set; }
        [NotMapped]
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int? DailyForecastId { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
    }

    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }        
        public double Pressure { get; set; }   
        public double Humidity { get; set; }    
        public double Temp_min { get; set; }    
        public double Temp_max { get; set; }    
    }

    public class Wind
    {
        public double Speed { get; set; }       
        public double Deg { get; set; }         
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public double Message { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class Temp
    {
        public double Day { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Night { get; set; }
        public double Eve { get; set; }
        public double Morn { get; set; }
    }

}