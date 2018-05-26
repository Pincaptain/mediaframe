namespace Mediaframe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Surname = c.String(maxLength: 120),
                        Avatar = c.String(),
                        AccountId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "AccountId" });
            DropTable("dbo.Users");
        }
    }
}
