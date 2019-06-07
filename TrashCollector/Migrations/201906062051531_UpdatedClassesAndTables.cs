namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClassesAndTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressNumber = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ApplicationId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "AddressId");
            CreateIndex("dbo.Customers", "ApplicationId");
            CreateIndex("dbo.Employees", "AddressId");
            CreateIndex("dbo.Employees", "ApplicationId");
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Employees", new[] { "ApplicationId" });
            DropIndex("dbo.Employees", new[] { "AddressId" });
            DropIndex("dbo.Customers", new[] { "ApplicationId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropColumn("dbo.Employees", "ApplicationId");
            DropColumn("dbo.Employees", "AddressId");
            DropColumn("dbo.Customers", "ApplicationId");
            DropColumn("dbo.Customers", "AddressId");
            DropTable("dbo.Addresses");
        }
    }
}
