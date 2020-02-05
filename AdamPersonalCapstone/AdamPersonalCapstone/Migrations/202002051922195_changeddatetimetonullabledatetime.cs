namespace AdamPersonalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddatetimetonullabledatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "MessageSent", c => c.DateTime());
            AlterColumn("dbo.Tickets", "MessageReceived", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "MessageReceived", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "MessageSent", c => c.DateTime(nullable: false));
        }
    }
}
