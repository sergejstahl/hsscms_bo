namespace hsscms_bo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "value", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "value");
        }
    }
}
