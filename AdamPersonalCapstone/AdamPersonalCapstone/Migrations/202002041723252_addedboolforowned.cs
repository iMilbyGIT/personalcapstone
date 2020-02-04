namespace AdamPersonalCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedboolforowned : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Owned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Owned");
        }
    }
}
