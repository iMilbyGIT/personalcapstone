namespace AdamPersonalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Tickets", new[] { "EmployeeId" });
            AlterColumn("dbo.Tickets", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Tickets", "EmployeeId");
            AddForeignKey("dbo.Tickets", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Tickets", new[] { "EmployeeId" });
            AlterColumn("dbo.Tickets", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "EmployeeId");
            AddForeignKey("dbo.Tickets", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
