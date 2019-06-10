namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSuspendPickUpType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "SuspendPickUp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "SuspendPickUp", c => c.String());
        }
    }
}
