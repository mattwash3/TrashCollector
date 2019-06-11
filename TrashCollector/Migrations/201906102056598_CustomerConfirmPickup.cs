namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerConfirmPickup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ConfirmPickup", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ConfirmPickup");
        }
    }
}
