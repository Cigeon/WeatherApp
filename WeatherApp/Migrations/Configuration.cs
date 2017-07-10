namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WeatherApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WeatherContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WeatherApp.Models.WeatherContext";
        }

        protected override void Seed(WeatherContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.SelectedCities.AddOrUpdate(
                s => s.Name,
                new SelectedCity { Name = "Kyiv" },
                new SelectedCity { Name = "Lviv"},
                new SelectedCity { Name = "Kharkiv" },
                new SelectedCity { Name = "Dnipro" },
                new SelectedCity { Name = "Odessa" }
            );
            
        }
    }
}
