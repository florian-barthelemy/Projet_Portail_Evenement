namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModels2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "Creator_Id", c => c.Int());
            CreateIndex("dbo.Event", "Creator_Id");
            AddForeignKey("dbo.Event", "Creator_Id", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "Creator_Id", "dbo.User");
            DropIndex("dbo.Event", new[] { "Creator_Id" });
            AlterColumn("dbo.Event", "Creator_Id", c => c.Int(nullable: false));
        }
    }
}
