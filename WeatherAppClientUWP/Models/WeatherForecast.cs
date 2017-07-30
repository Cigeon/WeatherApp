using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherAppClientUWP.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        [Display(Name = "Date")]
        public DateTime Dt { get; set; }
        public City City { get; set; }
        public string Cod { get; set; }
        public double Message { get; set; }
        public int Cnt { get; set; }
        public List<DailyForecast> List { get; set; }
        [Display(Name = "City")]
        public string ReqCity { get; set; }
        [Display(Name = "Period (days)")]
        public string ReqPeriod { get; set; }
    }
}