namespace GnistlyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedForeignKeysNotNUllAddedPasswords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Password",
                c => new
                    {
                        PasswordChars = c.String(nullable: false, maxLength: 6),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PasswordChars)
                .ForeignKey("dbo.tbl_User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            AddColumn("dbo.tbl_File", "IdeaID", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_User", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_ZipCode", "ZipCodeCity", c => c.String());
            CreateIndex("dbo.tbl_Comment", "IdeaID");
            CreateIndex("dbo.tbl_Idea", "UserID");
            CreateIndex("dbo.tbl_User", "DepartmentID");
            CreateIndex("dbo.tbl_User", "CustomerID");
            CreateIndex("dbo.tbl_Edit", "IdeaID");
            CreateIndex("dbo.tbl_Edit", "UserID");
            CreateIndex("dbo.tbl_File", "IdeaID");
            CreateIndex("dbo.tbl_Hashtag", "IdeaID");
            CreateIndex("dbo.tbl_Status", "IdeaID");
            CreateIndex("dbo.tbl_Task", "IdeaID");
            CreateIndex("dbo.tbl_Url", "CustomerID");
            AddForeignKey("dbo.tbl_User", "CustomerID", "dbo.tbl_Customers", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_User", "DepartmentID", "dbo.tbl_Deparment", "DepartmentID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_Idea", "UserID", "dbo.tbl_User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_Comment", "IdeaID", "dbo.tbl_Idea", "IdeaID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_Edit", "IdeaID", "dbo.tbl_Idea", "IdeaID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_Edit", "UserID", "dbo.tbl_User", "UserID", cascadeDelete: false);
            AddForeignKey("dbo.tbl_File", "IdeaID", "dbo.tbl_Idea", "IdeaID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_Hashtag", "IdeaID", "dbo.tbl_Idea", "IdeaID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_Status", "IdeaID", "dbo.tbl_Idea", "IdeaID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_Task", "IdeaID", "dbo.tbl_Idea", "IdeaID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_Url", "CustomerID", "dbo.tbl_Customers", "CustomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Url", "CustomerID", "dbo.tbl_Customers");
            DropForeignKey("dbo.tbl_Task", "IdeaID", "dbo.tbl_Idea");
            DropForeignKey("dbo.tbl_Status", "IdeaID", "dbo.tbl_Idea");
            DropForeignKey("dbo.tbl_Password", "UserID", "dbo.tbl_User");
            DropForeignKey("dbo.tbl_Hashtag", "IdeaID", "dbo.tbl_Idea");
            DropForeignKey("dbo.tbl_File", "IdeaID", "dbo.tbl_Idea");
            DropForeignKey("dbo.tbl_Edit", "UserID", "dbo.tbl_User");
            DropForeignKey("dbo.tbl_Edit", "IdeaID", "dbo.tbl_Idea");
            DropForeignKey("dbo.tbl_Comment", "IdeaID", "dbo.tbl_Idea");
            DropForeignKey("dbo.tbl_Idea", "UserID", "dbo.tbl_User");
            DropForeignKey("dbo.tbl_User", "DepartmentID", "dbo.tbl_Deparment");
            DropForeignKey("dbo.tbl_User", "CustomerID", "dbo.tbl_Customers");
            DropIndex("dbo.tbl_Url", new[] { "CustomerID" });
            DropIndex("dbo.tbl_Task", new[] { "IdeaID" });
            DropIndex("dbo.tbl_Status", new[] { "IdeaID" });
            DropIndex("dbo.tbl_Password", new[] { "UserID" });
            DropIndex("dbo.tbl_Hashtag", new[] { "IdeaID" });
            DropIndex("dbo.tbl_File", new[] { "IdeaID" });
            DropIndex("dbo.tbl_Edit", new[] { "UserID" });
            DropIndex("dbo.tbl_Edit", new[] { "IdeaID" });
            DropIndex("dbo.tbl_User", new[] { "CustomerID" });
            DropIndex("dbo.tbl_User", new[] { "DepartmentID" });
            DropIndex("dbo.tbl_Idea", new[] { "UserID" });
            DropIndex("dbo.tbl_Comment", new[] { "IdeaID" });
            AlterColumn("dbo.tbl_ZipCode", "ZipCodeCity", c => c.String(nullable: false));
            DropColumn("dbo.tbl_User", "CustomerID");
            DropColumn("dbo.tbl_File", "IdeaID");
            DropTable("dbo.tbl_Password");
        }
    }
}
