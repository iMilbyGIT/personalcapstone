namespace AdamPersonalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnenewnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "TicketSent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "TicketComplete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "TicketComplete");
            DropColumn("dbo.Customers", "TicketSent");
        }
    }
}
