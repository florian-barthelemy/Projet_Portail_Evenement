namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutEventSousCatId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SousCategorie", name: "EventCategorie_Id", newName: "EventCategorieId");
            RenameIndex(table: "dbo.SousCategorie", name: "IX_EventCategorie_Id", newName: "IX_EventCategorieId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SousCategorie", name: "IX_EventCategorieId", newName: "IX_EventCategorie_Id");
            RenameColumn(table: "dbo.SousCategorie", name: "EventCategorieId", newName: "EventCategorie_Id");
        }
    }
}
