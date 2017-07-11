using System.Configuration;
using System.Data.Entity;
using WeatherApp.App_Start;

namespace WeatherApp.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString)
        {
            // Initialize database
            Database.SetInitializer<WeatherContext>(new DbInitializer());
        }

        public DbSet<SelectedCity> SelectedCities { get; set; }
        public DbSet<SelectedPeriod> SelectedPeriods { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<DailyForecast> DailyForecasts { get; set; }
        public DbSet<Weather> Weathers { get; set; }
    }
}