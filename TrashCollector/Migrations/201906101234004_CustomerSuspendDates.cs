namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerSuspendDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SuspendPickUpStart", c => c.DateTime());
            AddColumn("dbo.Customers", "SuspendPickUpEnd", c => c.DateTime());
            DropColumn("dbo.Customers", "SuspendPickUp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SuspendPickUp", c => c.DateTime());
            DropColumn("dbo.Customers", "SuspendPickUpEnd");
            DropColumn("dbo.Customers", "SuspendPickUpStart");
        }
    }
}
