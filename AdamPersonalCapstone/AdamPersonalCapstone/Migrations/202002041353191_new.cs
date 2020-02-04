namespace AdamPersonalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "TicketPending", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "TicketSent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "TicketSent", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "TicketPending");
        }
    }
}
