namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventPhotos2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "UserUploader_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Photos", "UserUploader_Id");
            AddForeignKey("dbo.Photos", "UserUploader_Id", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "UserUploader_Id", "dbo.User");
            DropIndex("dbo.Photos", new[] { "UserUploader_Id" });
            DropColumn("dbo.Photos", "UserUploader_Id");
        }
    }
}
