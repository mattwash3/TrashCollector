namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustPickUpTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "OneTimePickUp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "OneTimePickUp", c => c.String());
        }
    }
}
