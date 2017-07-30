using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherAppClientUWP.Models
{
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
}