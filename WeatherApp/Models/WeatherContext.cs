using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeatherApp.App_Start;

namespace WeatherApp.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("DbConnection")
        {
            // Initialize database
            Database.SetInitializer<WeatherContext>(new DbInitializer());
        }

        public DbSet<SelectedCity> SelectedCities { get; set; }
        public DbSet<SelectedPeriod> SelectedPeriods { get; set; }
        public DbSet<ResponseWeatherForecast> WeatherForecasts { get; set; }
        public DbSet<DailyForecast> DailyForecasts { get; set; }
        public DbSet<Weather> Weathers { get; set; }
    }
}