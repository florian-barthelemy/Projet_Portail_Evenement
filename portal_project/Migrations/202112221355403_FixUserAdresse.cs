namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserAdresse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adresse", "User_Id1", "dbo.User");
            DropIndex("dbo.Adresse", new[] { "User_Id1" });
            RenameColumn(table: "dbo.User", name: "MainAdresse_Id", newName: "MainAdresseId");
            RenameIndex(table: "dbo.User", name: "IX_MainAdresse_Id", newName: "IX_MainAdresseId");
            DropColumn("dbo.Adresse", "User_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adresse", "User_Id1", c => c.Int());
            RenameIndex(table: "dbo.User", name: "IX_MainAdresseId", newName: "IX_MainAdresse_Id");
            RenameColumn(table: "dbo.User", name: "MainAdresseId", newName: "MainAdresse_Id");
            CreateIndex("dbo.Adresse", "User_Id1");
            AddForeignKey("dbo.Adresse", "User_Id1", "dbo.User", "Id");
        }
    }
}
