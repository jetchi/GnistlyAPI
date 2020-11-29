namespace GnistlyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNavigationCustomerToZipCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Customers", "Zip", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbl_Customers", "Zip");
            AddForeignKey("dbo.tbl_Customers", "Zip", "dbo.tbl_ZipCode", "Zip");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Customers", "Zip", "dbo.tbl_ZipCode");
            DropIndex("dbo.tbl_Customers", new[] { "Zip" });
            AlterColumn("dbo.tbl_Customers", "Zip", c => c.String(maxLength: 4));
        }
    }
}
