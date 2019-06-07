namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerInfoAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "WeeklyPickUp", c => c.String());
            AddColumn("dbo.Customers", "OneTimePickUp", c => c.String());
            AddColumn("dbo.Customers", "SuspendPickUp", c => c.String());
            AddColumn("dbo.Customers", "PickUpTotalFees", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PickUpTotalFees");
            DropColumn("dbo.Customers", "SuspendPickUp");
            DropColumn("dbo.Customers", "OneTimePickUp");
            DropColumn("dbo.Customers", "WeeklyPickUp");
        }
    }
}
