using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
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
}