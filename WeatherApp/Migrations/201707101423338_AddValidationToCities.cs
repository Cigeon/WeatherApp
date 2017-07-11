namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToCities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SelectedCities", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SelectedCities", "Text", c => c.String());
        }
    }
}
