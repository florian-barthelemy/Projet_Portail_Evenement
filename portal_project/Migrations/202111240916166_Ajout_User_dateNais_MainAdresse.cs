namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajout_User_dateNais_MainAdresse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adresse", "User_Id", "dbo.User");
            AddColumn("dbo.Adresse", "User_Id1", c => c.Int());
            AddColumn("dbo.User", "DateNais", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "MainAdresse_Id", c => c.Int());
            CreateIndex("dbo.Adresse", "User_Id1");
            CreateIndex("dbo.User", "MainAdresse_Id");
            AddForeignKey("dbo.User", "MainAdresse_Id", "dbo.Adresse", "Id");
            AddForeignKey("dbo.Adresse", "User_Id1", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adresse", "User_Id1", "dbo.User");
            DropForeignKey("dbo.User", "MainAdresse_Id", "dbo.Adresse");
            DropIndex("dbo.User", new[] { "MainAdresse_Id" });
            DropIndex("dbo.Adresse", new[] { "User_Id1" });
            DropColumn("dbo.User", "MainAdresse_Id");
            DropColumn("dbo.User", "DateNais");
            DropColumn("dbo.Adresse", "User_Id1");
            AddForeignKey("dbo.Adresse", "User_Id", "dbo.User", "Id");
        }
    }
}
