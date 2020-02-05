namespace AdamPersonalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hadissuesdeletedpriormigrations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Customer_CustomerId1", c => c.Int());
            CreateIndex("dbo.Devices", "Customer_CustomerId1");
            AddForeignKey("dbo.Devices", "Customer_CustomerId1", "dbo.Customers", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "Customer_CustomerId1", "dbo.Customers");
            DropIndex("dbo.Devices", new[] { "Customer_CustomerId1" });
            DropColumn("dbo.Devices", "Customer_CustomerId1");
        }
    }
}
