namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voie = c.String(),
                        CodePostal = c.String(),
                        Ville = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        Description = c.String(),
                        Adresse = c.String(),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        Creator_Id = c.Int(nullable: false),
                        Tarif = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Adresse_Id = c.Int(nullable: false),
                        Event_Id = c.Int(),
                        Event_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.Event_Id)
                .ForeignKey("dbo.Event", t => t.Event_Id1)
                .Index(t => t.Event_Id)
                .Index(t => t.Event_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Event_Id1", "dbo.Event");
            DropForeignKey("dbo.User", "Event_Id", "dbo.Event");
            DropIndex("dbo.User", new[] { "Event_Id1" });
            DropIndex("dbo.User", new[] { "Event_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Event");
            DropTable("dbo.Adresse");
        }
    }
}
