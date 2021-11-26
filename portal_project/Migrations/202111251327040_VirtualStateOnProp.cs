namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualStateOnProp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventSousCategories", "Event_Id", "dbo.Event");
            DropForeignKey("dbo.EventSousCategories", "SousCategorie_Id", "dbo.SousCategorie");
            DropIndex("dbo.Categorie", new[] { "Event_Id" });
            DropIndex("dbo.EventSousCategories", new[] { "Event_Id" });
            DropIndex("dbo.EventSousCategories", new[] { "SousCategorie_Id" });
            RenameColumn(table: "dbo.Event", name: "Event_Id", newName: "EventCat_Id");
            AddColumn("dbo.Event", "EventSousCat_Id", c => c.Int());
            CreateIndex("dbo.Event", "EventCat_Id");
            CreateIndex("dbo.Event", "EventSousCat_Id");
            AddForeignKey("dbo.Event", "EventSousCat_Id", "dbo.SousCategorie", "Id");
            DropColumn("dbo.Categorie", "Event_Id");
            DropTable("dbo.EventSousCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventSousCategories",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        SousCategorie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.SousCategorie_Id });
            
            AddColumn("dbo.Categorie", "Event_Id", c => c.Int());
            DropForeignKey("dbo.Event", "EventSousCat_Id", "dbo.SousCategorie");
            DropIndex("dbo.Event", new[] { "EventSousCat_Id" });
            DropIndex("dbo.Event", new[] { "EventCat_Id" });
            DropColumn("dbo.Event", "EventSousCat_Id");
            RenameColumn(table: "dbo.Event", name: "EventCat_Id", newName: "Event_Id");
            CreateIndex("dbo.EventSousCategories", "SousCategorie_Id");
            CreateIndex("dbo.EventSousCategories", "Event_Id");
            CreateIndex("dbo.Categorie", "Event_Id");
            AddForeignKey("dbo.EventSousCategories", "SousCategorie_Id", "dbo.SousCategorie", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EventSousCategories", "Event_Id", "dbo.Event", "Id", cascadeDelete: true);
        }
    }
}
