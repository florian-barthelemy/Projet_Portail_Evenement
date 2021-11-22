namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutCategorie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "Creator_Id", "dbo.User");
            DropIndex("dbo.Event", new[] { "Creator_Id" });
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SousCategorie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Categorie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorie", t => t.Categorie_Id)
                .Index(t => t.Categorie_Id);
            
            AlterColumn("dbo.Event", "Creator_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Event", "Creator_Id");
            AddForeignKey("dbo.Event", "Creator_Id", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "Creator_Id", "dbo.User");
            DropForeignKey("dbo.SousCategorie", "Categorie_Id", "dbo.Categorie");
            DropIndex("dbo.SousCategorie", new[] { "Categorie_Id" });
            DropIndex("dbo.Event", new[] { "Creator_Id" });
            AlterColumn("dbo.Event", "Creator_Id", c => c.Int());
            DropTable("dbo.SousCategorie");
            DropTable("dbo.Categorie");
            CreateIndex("dbo.Event", "Creator_Id");
            AddForeignKey("dbo.Event", "Creator_Id", "dbo.User", "Id");
        }
    }
}
