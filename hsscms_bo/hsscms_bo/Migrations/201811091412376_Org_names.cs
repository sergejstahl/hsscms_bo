namespace hsscms_bo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Org_names : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organisations", "wyw", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organisations", "wyw");
        }
    }
}
