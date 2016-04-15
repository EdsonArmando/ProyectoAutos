namespace AutoVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class de_autos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Automovils", "combustible", c => c.String(nullable: false));
            AddColumn("dbo.Automovils", "cilindrada", c => c.String(nullable: false));
            AddColumn("dbo.Automovils", "motor", c => c.String(nullable: false));
            AddColumn("dbo.Automovils", "manufacturacion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Automovils", "manufacturacion");
            DropColumn("dbo.Automovils", "motor");
            DropColumn("dbo.Automovils", "cilindrada");
            DropColumn("dbo.Automovils", "combustible");
        }
    }
}
