namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 200),
                        WebSite = c.String(maxLength: 200),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        page_OageId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Pages", t => t.page_OageId)
                .Index(t => t.page_OageId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        OageId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        ShortDescription = c.String(nullable: false, maxLength: 350),
                        PageText = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        ImageName = c.String(),
                        ShowInSlider = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OageId)
                .ForeignKey("dbo.PageGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "GroupId", "dbo.PageGroups");
            DropForeignKey("dbo.PageComments", "page_OageId", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "GroupId" });
            DropIndex("dbo.PageComments", new[] { "page_OageId" });
            DropTable("dbo.PageGroups");
            DropTable("dbo.Pages");
            DropTable("dbo.PageComments");
        }
    }
}
