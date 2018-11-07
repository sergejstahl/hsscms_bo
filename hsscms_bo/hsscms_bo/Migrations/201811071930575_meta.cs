namespace hsscms_bo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cities", "name", c => c.String());
        }
    }
}
