namespace hsscms_bo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Org : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        oid = c.Int(nullable: false),
                        shortName = c.String(),
                        titleName = c.String(),
                        fullName = c.String(),
                        foundingDate = c.String(),
                        description = c.String(),
                        city_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cities", t => t.city_id)
                .Index(t => t.city_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organisations", "city_id", "dbo.Cities");
            DropIndex("dbo.Organisations", new[] { "city_id" });
            DropTable("dbo.Organisations");
        }
    }
}
