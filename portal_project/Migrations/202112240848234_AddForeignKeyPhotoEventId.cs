namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPhotoEventId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "PhotoEvent_Id", "dbo.Event");
            DropIndex("dbo.Photos", new[] { "PhotoEvent_Id" });
            RenameColumn(table: "dbo.Photos", name: "PhotoEvent_Id", newName: "PhotoEventId");
            AlterColumn("dbo.Photos", "PhotoEventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Photos", "PhotoEventId");
            AddForeignKey("dbo.Photos", "PhotoEventId", "dbo.Event", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "PhotoEventId", "dbo.Event");
            DropIndex("dbo.Photos", new[] { "PhotoEventId" });
            AlterColumn("dbo.Photos", "PhotoEventId", c => c.Int());
            RenameColumn(table: "dbo.Photos", name: "PhotoEventId", newName: "PhotoEvent_Id");
            CreateIndex("dbo.Photos", "PhotoEvent_Id");
            AddForeignKey("dbo.Photos", "PhotoEvent_Id", "dbo.Event", "Id");
        }
    }
}
