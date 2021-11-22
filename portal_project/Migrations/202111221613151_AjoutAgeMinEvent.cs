namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutAgeMinEvent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Event", name: "Event_Adresse_Id", newName: "EventAdresse_Id");
            RenameIndex(table: "dbo.Event", name: "IX_Event_Adresse_Id", newName: "IX_EventAdresse_Id");
            AddColumn("dbo.Event", "MinAge", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "MinAge");
            RenameIndex(table: "dbo.Event", name: "IX_EventAdresse_Id", newName: "IX_Event_Adresse_Id");
            RenameColumn(table: "dbo.Event", name: "EventAdresse_Id", newName: "Event_Adresse_Id");
        }
    }
}
