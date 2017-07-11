namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSelectedPeriods : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SelectedPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SelectedCities", "Text", c => c.String());
            AddColumn("dbo.SelectedCities", "Value", c => c.String());
            DropColumn("dbo.SelectedCities", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SelectedCities", "Name", c => c.String());
            DropColumn("dbo.SelectedCities", "Value");
            DropColumn("dbo.SelectedCities", "Text");
            DropTable("dbo.SelectedPeriods");
        }
    }
}
