namespace dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        index = c.String(),
                        region = c.String(),
                        street = c.String(),
                        city_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cities", t => t.city_id, cascadeDelete: true)
                .Index(t => t.city_id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        value = c.String(),
                        type_id = c.Int(nullable: false),
                        Organisation_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ContactTypes", t => t.type_id, cascadeDelete: true)
                .ForeignKey("dbo.Organisations", t => t.Organisation_id)
                .Index(t => t.type_id)
                .Index(t => t.Organisation_id);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
            
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        oid = c.Int(nullable: false),
                        wyw = c.Int(nullable: false),
                        shortName = c.String(),
                        titleName = c.String(),
                        fullName = c.String(),
                        foundingDate = c.String(),
                        description = c.String(),
                        department = c.String(),
                        tmp_opistow = c.String(),
                        tmp_znak_ris = c.String(),
                        tmp_opisl = c.String(),
                        tmp_opisd = c.String(),
                        tmp_rekl_ris = c.String(),
                        tmp_otrasl = c.String(),
                        tmp_istor = c.String(),
                        tmp_face_ris = c.String(),
                        tmp_meta = c.String(),
                        tmp_data_izm = c.String(),
                        tmp_sluzebnaja = c.String(),
                        tmp_sort = c.Int(nullable: false),
                        adress_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Adresses", t => t.adress_id)
                .Index(t => t.adress_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goods", "Organisation_id", "dbo.Organisations");
            DropForeignKey("dbo.Contacts", "Organisation_id", "dbo.Organisations");
            DropForeignKey("dbo.Organisations", "adress_id", "dbo.Adresses");
            DropForeignKey("dbo.Contacts", "type_id", "dbo.ContactTypes");
            DropForeignKey("dbo.Adresses", "city_id", "dbo.Cities");
            DropIndex("dbo.Organisations", new[] { "adress_id" });
            DropIndex("dbo.Goods", new[] { "Organisation_id" });
            DropIndex("dbo.Contacts", new[] { "Organisation_id" });
            DropIndex("dbo.Contacts", new[] { "type_id" });
            DropIndex("dbo.Adresses", new[] { "city_id" });
            DropTable("dbo.Organisations");
            DropTable("dbo.Goods");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
            DropTable("dbo.Cities");
            DropTable("dbo.Adresses");
        }
    }
}
