namespace GnistlyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(maxLength: 200),
                        CustomerMail = c.String(),
                        CustomerStatus = c.Boolean(nullable: false),
                        CustomerPhone = c.String(),
                        CustomerStreet = c.String(),
                        Zip = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ZipCodes", t => t.Zip)
                .Index(t => t.Zip);
            
            CreateTable(
                "dbo.ZipCodes",
                c => new
                    {
                        Zip = c.String(nullable: false, maxLength: 128),
                        ZipCodeCity = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Zip);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Customers", "Zip", "dbo.ZipCodes");
            DropIndex("dbo.tbl_Customers", new[] { "Zip" });
            DropTable("dbo.ZipCodes");
            DropTable("dbo.tbl_Customers");
        }
    }
}
