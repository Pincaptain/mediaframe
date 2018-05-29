namespace Mediaframe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Posts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 120),
                        DateAdded = c.DateTime(nullable: false),
                        PostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false, maxLength: 600),
                        Description = c.String(maxLength: 240),
                        UserId = c.Int(),
                        User_Id = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1);
            
            AddColumn("dbo.Users", "Post_Id", c => c.Int());
            CreateIndex("dbo.Users", "Post_Id");
            AddForeignKey("dbo.Users", "Post_Id", "dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Users", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id1" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropColumn("dbo.Users", "Post_Id");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
