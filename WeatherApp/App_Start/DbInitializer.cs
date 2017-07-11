using System.Data.Entity;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.App_Start
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            // Create repository instance
            var repo = new Repository();

            // Add default cities to dropdown list "Select city"
            repo.AddCity(new SelectedCity { Text = "Kyiv", Value = "Kyiv" });
            repo.AddCity(new SelectedCity { Text = "Lviv", Value = "Lviv" });
            repo.AddCity(new SelectedCity { Text = "Kharkiv", Value = "Kharkiv" });
            repo.AddCity(new SelectedCity { Text = "Dnipro", Value = "Dnipro" });
            repo.AddCity(new SelectedCity { Text = "Odessa", Value = "Odessa" });

            // Add default periods to dropdown list "Select period"
            repo.AddParameter(new SelectedPeriod { Text = "Current weather", Value = "1" });
            repo.AddParameter(new SelectedPeriod { Text = "For 3 days", Value = "3" });
            repo.AddParameter(new SelectedPeriod { Text = "For 7 days", Value = "7" });

            context.SaveChanges();
        }
    }
    
}