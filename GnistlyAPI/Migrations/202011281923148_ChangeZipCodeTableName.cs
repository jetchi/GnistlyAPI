namespace GnistlyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeZipCodeTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ZipCodes", newName: "tbl_ZipCode");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tbl_ZipCode", newName: "ZipCodes");
        }
    }
}
