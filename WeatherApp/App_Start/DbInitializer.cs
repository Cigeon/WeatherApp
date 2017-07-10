using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeatherApp.Models;

namespace WeatherApp.App_Start
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            // Add default cities to dropdown list
            context.SelectedCities.Add(new SelectedCity { Name = "Kyiv" });
            context.SelectedCities.Add(new SelectedCity { Name = "Lviv" });
            context.SelectedCities.Add(new SelectedCity { Name = "Kharkiv" });
            context.SelectedCities.Add(new SelectedCity { Name = "Dnipro" });
            context.SelectedCities.Add(new SelectedCity { Name = "Odessa" });
            context.SaveChanges();
        }
    }
    
}