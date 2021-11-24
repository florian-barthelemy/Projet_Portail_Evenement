namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventPhotos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoLocation = c.String(nullable: false),
                        PhotoTitle = c.String(nullable: false),
                        PhotoDescription = c.String(nullable: false),
                        DateUpload = c.DateTime(nullable: false),
                        PhotoEvent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.PhotoEvent_Id)
                .Index(t => t.PhotoEvent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "PhotoEvent_Id", "dbo.Event");
            DropIndex("dbo.Photos", new[] { "PhotoEvent_Id" });
            DropTable("dbo.Photos");
        }
    }
}
