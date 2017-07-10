namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeparateResponseClasses : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ResponseWeatherForecasts", newName: "WeatherForecasts");
            DropColumn("dbo.DailyForecasts", "WeatherForecastId");
            RenameColumn(table: "dbo.DailyForecasts", name: "ResponseWeatherForecast_Id", newName: "WeatherForecastId");
            RenameIndex(table: "dbo.DailyForecasts", name: "IX_ResponseWeatherForecast_Id", newName: "IX_WeatherForecastId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DailyForecasts", name: "IX_WeatherForecastId", newName: "IX_ResponseWeatherForecast_Id");
            RenameColumn(table: "dbo.DailyForecasts", name: "WeatherForecastId", newName: "ResponseWeatherForecast_Id");
            AddColumn("dbo.DailyForecasts", "WeatherForecastId", c => c.Int());
            RenameTable(name: "dbo.WeatherForecasts", newName: "ResponseWeatherForecasts");
        }
    }
}
