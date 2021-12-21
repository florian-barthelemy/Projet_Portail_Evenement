namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectEvent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Event", name: "EventSousCat_Id", newName: "EventSousCatId");
            RenameIndex(table: "dbo.Event", name: "IX_EventSousCat_Id", newName: "IX_EventSousCatId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Event", name: "IX_EventSousCatId", newName: "IX_EventSousCat_Id");
            RenameColumn(table: "dbo.Event", name: "EventSousCatId", newName: "EventSousCat_Id");
        }
    }
}
