namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEventAdresse : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Event", name: "EventAdresse_Id", newName: "EventAdresseId");
            RenameIndex(table: "dbo.Event", name: "IX_EventAdresse_Id", newName: "IX_EventAdresseId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Event", name: "IX_EventAdresseId", newName: "IX_EventAdresse_Id");
            RenameColumn(table: "dbo.Event", name: "EventAdresseId", newName: "EventAdresse_Id");
        }
    }
}
