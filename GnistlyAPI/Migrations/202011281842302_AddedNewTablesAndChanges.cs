namespace GnistlyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewTablesAndChanges : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tbl_Customers");
            CreateTable(
                "dbo.tbl_Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        IdeaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.tbl_Deparment",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.tbl_Edit",
                c => new
                    {
                        EditID = c.Int(nullable: false, identity: true),
                        EditDate = c.DateTime(nullable: false),
                        IdeaID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EditID);
            
            CreateTable(
                "dbo.tbl_File",
                c => new
                    {
                        FileName = c.String(nullable: false, maxLength: 128),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.FileName);
            
            CreateTable(
                "dbo.tbl_Hashtag",
                c => new
                    {
                        HashtagID = c.Int(nullable: false, identity: true),
                        HashtagText = c.String(),
                        IdeaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HashtagID);
            
            CreateTable(
                "dbo.tbl_Idea",
                c => new
                    {
                        IdeaID = c.Int(nullable: false, identity: true),
                        IdeaTitle = c.String(),
                        IdeaDescription = c.String(),
                        IdeaDate = c.DateTime(nullable: false),
                        IdeaImpact = c.Int(nullable: false),
                        IdeaEffort = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        IdeaSavings = c.Int(nullable: false),
                        IdeaChallenges = c.String(),
                        IdeaResults = c.String(),
                    })
                .PrimaryKey(t => t.IdeaID);
            
            CreateTable(
                "dbo.tbl_Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusDescription = c.String(),
                        IdeaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.tbl_Task",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        IdeaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
            CreateTable(
                "dbo.tbl_Url",
                c => new
                    {
                        UrlID = c.Int(nullable: false, identity: true),
                        UrlDate = c.DateTime(nullable: false),
                        UrlString = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrlID);
            
            CreateTable(
                "dbo.tbl_User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserFname = c.String(),
                        UserLname = c.String(),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            DropColumn("dbo.tbl_Customers", "ID"); // if you change something with the PK, make sure to make all drop operations before the new Add operations! otherwise an exception will occur due to multiple identity columns specified. 
            AddColumn("dbo.tbl_Customers", "CustomerID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.tbl_Customers", "CustomerName", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Customers", "Zip", c => c.String(maxLength: 4));
            AlterColumn("dbo.ZipCodes", "ZipCodeCity", c => c.String(nullable: false));
            AddPrimaryKey("dbo.tbl_Customers", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Customers", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.tbl_Customers");
            AlterColumn("dbo.ZipCodes", "ZipCodeCity", c => c.String(maxLength: 150));
            AlterColumn("dbo.tbl_Customers", "Zip", c => c.String(maxLength: 6));
            AlterColumn("dbo.tbl_Customers", "CustomerName", c => c.String(maxLength: 200));
            DropColumn("dbo.tbl_Customers", "CustomerID");
            DropTable("dbo.tbl_User");
            DropTable("dbo.tbl_Url");
            DropTable("dbo.tbl_Task");
            DropTable("dbo.tbl_Status");
            DropTable("dbo.tbl_Idea");
            DropTable("dbo.tbl_Hashtag");
            DropTable("dbo.tbl_File");
            DropTable("dbo.tbl_Edit");
            DropTable("dbo.tbl_Deparment");
            DropTable("dbo.tbl_Comment");
            AddPrimaryKey("dbo.tbl_Customers", "ID");
        }
    }
}
