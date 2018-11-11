namespace hsscms_bo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Step02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adresses", "index", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adresses", "index", c => c.Int(nullable: false));
        }
    }
}
