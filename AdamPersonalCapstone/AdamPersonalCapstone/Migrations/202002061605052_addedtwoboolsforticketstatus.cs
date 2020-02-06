namespace AdamPersonalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtwoboolsforticketstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "isClaimed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "isCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "isCompleted");
            DropColumn("dbo.Tickets", "isClaimed");
        }
    }
}
