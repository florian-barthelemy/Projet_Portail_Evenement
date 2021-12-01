namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFixDateNaisAndAddGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserGenre", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "DateNais", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "DateNais", c => c.DateTime(nullable: false));
            DropColumn("dbo.User", "UserGenre");
        }
    }
}
