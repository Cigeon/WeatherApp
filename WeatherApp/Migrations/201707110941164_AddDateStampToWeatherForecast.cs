namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateStampToWeatherForecast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeatherForecasts", "Dt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeatherForecasts", "Dt");
        }
    }
}
