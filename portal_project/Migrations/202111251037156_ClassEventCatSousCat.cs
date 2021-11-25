namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassEventCatSousCat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventSousCategories",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        SousCategorie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.SousCategorie_Id })
                .ForeignKey("dbo.Event", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.SousCategorie", t => t.SousCategorie_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.SousCategorie_Id);
            
            AddColumn("dbo.Categorie", "Event_Id", c => c.Int());
            CreateIndex("dbo.Categorie", "Event_Id");
            AddForeignKey("dbo.Categorie", "Event_Id", "dbo.Event", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventSousCategories", "SousCategorie_Id", "dbo.SousCategorie");
            DropForeignKey("dbo.EventSousCategories", "Event_Id", "dbo.Event");
            DropForeignKey("dbo.Categorie", "Event_Id", "dbo.Event");
            DropIndex("dbo.EventSousCategories", new[] { "SousCategorie_Id" });
            DropIndex("dbo.EventSousCategories", new[] { "Event_Id" });
            DropIndex("dbo.Categorie", new[] { "Event_Id" });
            DropColumn("dbo.Categorie", "Event_Id");
            DropTable("dbo.EventSousCategories");
        }
    }
}
