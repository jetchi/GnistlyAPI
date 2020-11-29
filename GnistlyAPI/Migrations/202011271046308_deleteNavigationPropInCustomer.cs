namespace GnistlyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteNavigationPropInCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_Customers", "Zip", "dbo.ZipCodes");
            DropIndex("dbo.tbl_Customers", new[] { "Zip" });
            AlterColumn("dbo.tbl_Customers", "Zip", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Customers", "Zip", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbl_Customers", "Zip");
            AddForeignKey("dbo.tbl_Customers", "Zip", "dbo.ZipCodes", "Zip");
        }
    }
}
