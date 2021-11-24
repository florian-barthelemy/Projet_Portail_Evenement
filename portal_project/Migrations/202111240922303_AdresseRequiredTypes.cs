namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdresseRequiredTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adresse", "Voie", c => c.String(nullable: false));
            AlterColumn("dbo.Adresse", "CodePostal", c => c.String(nullable: false));
            AlterColumn("dbo.Adresse", "Ville", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adresse", "Ville", c => c.String());
            AlterColumn("dbo.Adresse", "CodePostal", c => c.String());
            AlterColumn("dbo.Adresse", "Voie", c => c.String());
        }
    }
}
