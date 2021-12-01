namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDateAndCreatePhotoEvent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "UserUploader_Id", "dbo.User");
            DropIndex("dbo.Photos", new[] { "UserUploader_Id" });
            AlterColumn("dbo.Photos", "DateUpload", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Photos", "UserUploader_Id", c => c.Int());
            CreateIndex("dbo.Photos", "UserUploader_Id");
            AddForeignKey("dbo.Photos", "UserUploader_Id", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "UserUploader_Id", "dbo.User");
            DropIndex("dbo.Photos", new[] { "UserUploader_Id" });
            AlterColumn("dbo.Photos", "UserUploader_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Photos", "DateUpload", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Photos", "UserUploader_Id");
            AddForeignKey("dbo.Photos", "UserUploader_Id", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
