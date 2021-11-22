namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adresse", "User_Id", c => c.Int());
            AddColumn("dbo.Event", "Event_Adresse_Id", c => c.Int());
            CreateIndex("dbo.Adresse", "User_Id");
            CreateIndex("dbo.Event", "Event_Adresse_Id");
            AddForeignKey("dbo.Adresse", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Event", "Event_Adresse_Id", "dbo.Adresse", "Id");
            DropColumn("dbo.Event", "Adresse");
            DropColumn("dbo.User", "Adresse_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Adresse_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "Adresse", c => c.String());
            DropForeignKey("dbo.Event", "Event_Adresse_Id", "dbo.Adresse");
            DropForeignKey("dbo.Adresse", "User_Id", "dbo.User");
            DropIndex("dbo.Event", new[] { "Event_Adresse_Id" });
            DropIndex("dbo.Adresse", new[] { "User_Id" });
            DropColumn("dbo.Event", "Event_Adresse_Id");
            DropColumn("dbo.Adresse", "User_Id");
        }
    }
}
