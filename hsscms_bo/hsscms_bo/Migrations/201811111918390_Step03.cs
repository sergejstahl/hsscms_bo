namespace hsscms_bo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Step03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false),
                        Organisation_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Organisations", t => t.Organisation_id)
                .Index(t => t.Organisation_id);
            
            AddColumn("dbo.Organisations", "tmp_opistow", c => c.String());
            AddColumn("dbo.Organisations", "tmp_znak_ris", c => c.String());
            AddColumn("dbo.Organisations", "tmp_opisl", c => c.String());
            AddColumn("dbo.Organisations", "tmp_opisd", c => c.String());
            AddColumn("dbo.Organisations", "tmp_rekl_ris", c => c.String());
            AddColumn("dbo.Organisations", "tmp_otrasl", c => c.String());
            AddColumn("dbo.Organisations", "tmp_istor", c => c.String());
            AddColumn("dbo.Organisations", "tmp_face_ris", c => c.String());
            AddColumn("dbo.Organisations", "tmp_meta", c => c.String());
            AddColumn("dbo.Organisations", "tmp_data_izm", c => c.String());
            AddColumn("dbo.Organisations", "tmp_sluzebnaja", c => c.String());
            AddColumn("dbo.Organisations", "tmp_sort", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goods", "Organisation_id", "dbo.Organisations");
            DropIndex("dbo.Goods", new[] { "Organisation_id" });
            DropColumn("dbo.Organisations", "tmp_sort");
            DropColumn("dbo.Organisations", "tmp_sluzebnaja");
            DropColumn("dbo.Organisations", "tmp_data_izm");
            DropColumn("dbo.Organisations", "tmp_meta");
            DropColumn("dbo.Organisations", "tmp_face_ris");
            DropColumn("dbo.Organisations", "tmp_istor");
            DropColumn("dbo.Organisations", "tmp_otrasl");
            DropColumn("dbo.Organisations", "tmp_rekl_ris");
            DropColumn("dbo.Organisations", "tmp_opisd");
            DropColumn("dbo.Organisations", "tmp_opisl");
            DropColumn("dbo.Organisations", "tmp_znak_ris");
            DropColumn("dbo.Organisations", "tmp_opistow");
            DropTable("dbo.Goods");
        }
    }
}
