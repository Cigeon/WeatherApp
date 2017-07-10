namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyForecasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dt = c.Int(nullable: false),
                        Temp_Day = c.Double(nullable: false),
                        Temp_Min = c.Double(nullable: false),
                        Temp_Max = c.Double(nullable: false),
                        Temp_Night = c.Double(nullable: false),
                        Temp_Eve = c.Double(nullable: false),
                        Temp_Morn = c.Double(nullable: false),
                        Pressure = c.Double(nullable: false),
                        Humidity = c.Double(nullable: false),
                        Speed = c.Double(nullable: false),
                        Deg = c.Double(nullable: false),
                        Clouds = c.Double(nullable: false),
                        WeatherForecastId = c.Int(),
                        ResponseWeatherForecast_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResponseWeatherForecasts", t => t.ResponseWeatherForecast_Id)
                .Index(t => t.ResponseWeatherForecast_Id);
            
            CreateTable(
                "dbo.Weathers",
                c => new
                    {
                        WeatherId = c.Int(nullable: false, identity: true),
                        Main = c.String(),
                        Description = c.String(),
                        Icon = c.String(),
                        DailyForecastId = c.Int(),
                    })
                .PrimaryKey(t => t.WeatherId)
                .ForeignKey("dbo.DailyForecasts", t => t.DailyForecastId)
                .Index(t => t.DailyForecastId);
            
            CreateTable(
                "dbo.ResponseWeatherForecasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cod = c.String(),
                        Message = c.Double(nullable: false),
                        Cnt = c.Int(nullable: false),
                        ReqCity = c.String(),
                        ReqPeriod = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Coord_Lon = c.Double(nullable: false),
                        Coord_Lat = c.Double(nullable: false),
                        Country = c.String(),
                        Population = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyForecasts", "ResponseWeatherForecast_Id", "dbo.ResponseWeatherForecasts");
            DropForeignKey("dbo.ResponseWeatherForecasts", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Weathers", "DailyForecastId", "dbo.DailyForecasts");
            DropIndex("dbo.ResponseWeatherForecasts", new[] { "City_Id" });
            DropIndex("dbo.Weathers", new[] { "DailyForecastId" });
            DropIndex("dbo.DailyForecasts", new[] { "ResponseWeatherForecast_Id" });
            DropTable("dbo.Cities");
            DropTable("dbo.ResponseWeatherForecasts");
            DropTable("dbo.Weathers");
            DropTable("dbo.DailyForecasts");
        }
    }
}
