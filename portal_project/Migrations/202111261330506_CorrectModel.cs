namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SousCategorie", name: "Categorie_Id", newName: "EventCategorie_Id");
            RenameIndex(table: "dbo.SousCategorie", name: "IX_Categorie_Id", newName: "IX_EventCategorie_Id");
            AddColumn("dbo.Event", "EventSousCat_Id", c => c.Int());
            CreateIndex("dbo.Event", "EventSousCat_Id");
            AddForeignKey("dbo.Event", "EventSousCat_Id", "dbo.SousCategorie", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "EventSousCat_Id", "dbo.SousCategorie");
            DropIndex("dbo.Event", new[] { "EventSousCat_Id" });
            DropColumn("dbo.Event", "EventSousCat_Id");
            RenameIndex(table: "dbo.SousCategorie", name: "IX_EventCategorie_Id", newName: "IX_Categorie_Id");
            RenameColumn(table: "dbo.SousCategorie", name: "EventCategorie_Id", newName: "Categorie_Id");
        }
    }
}
