namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdresseCoordinatesTableToAxeDouble : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adresse", "Axe_X", c => c.Double(nullable: false));
            AddColumn("dbo.Adresse", "Axe_Y", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adresse", "Axe_Y");
            DropColumn("dbo.Adresse", "Axe_X");
        }
    }
}
