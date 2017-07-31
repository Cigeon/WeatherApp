using System.Data.Entity;
using WeatherApp.Models;
using WeatherApp.Repositories;

namespace WeatherApp.App_Start
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            // Add default cities to dropdown list "Select city"
            var cityRepo = new CityRepository();
            cityRepo.AddCityAsync(new SelectedCity { Text = "Kyiv", Value = "Kyiv" });
            cityRepo.AddCityAsync(new SelectedCity { Text = "Lviv", Value = "Lviv" });
            cityRepo.AddCityAsync(new SelectedCity { Text = "Kharkiv", Value = "Kharkiv" });
            cityRepo.AddCityAsync(new SelectedCity { Text = "Dnipro", Value = "Dnipro" });
            cityRepo.AddCityAsync(new SelectedCity { Text = "Odessa", Value = "Odessa" });

            // Add default periods to dropdown list "Select period"
            var paramRepo = new ParametersRepository();
            paramRepo.AddParameter(new SelectedPeriod { Text = "Current weather", Value = "1" });
            paramRepo.AddParameter(new SelectedPeriod { Text = "For 3 days", Value = "3" });
            paramRepo.AddParameter(new SelectedPeriod { Text = "For 7 days", Value = "7" });

            context.SaveChanges();
        }
    }
    
}