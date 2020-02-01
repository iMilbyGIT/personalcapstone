namespace AdamPersonalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnewnewwww : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "rateCount", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "averageRate", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "employeeRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "employeeRating");
            DropColumn("dbo.Employees", "averageRate");
            DropColumn("dbo.Employees", "rateCount");
        }
    }
}
