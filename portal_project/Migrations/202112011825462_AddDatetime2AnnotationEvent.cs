namespace portal_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatetime2AnnotationEvent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "DateDebut", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Event", "DateFin", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "DateFin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Event", "DateDebut", c => c.DateTime(nullable: false));
        }
    }
}
