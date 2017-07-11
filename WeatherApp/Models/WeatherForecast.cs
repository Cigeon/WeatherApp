using System;
using System.Collections.Generic;

namespace WeatherApp.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public City City { get; set; }
        public string Cod { get; set; }
        public double Message { get; set; }
        public int Cnt { get; set; }
        public List<DailyForecast> list { get; set; }
        public string ReqCity { get; set; }
        public string ReqPeriod { get; set; }
    }
}