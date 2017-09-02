namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TopicMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        OwnerId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Text = c.String(),
                        OwnerId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.TopicMessages", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.TopicMessages", "OwnerId", "dbo.Users");
            DropIndex("dbo.Topics", new[] { "OwnerId" });
            DropIndex("dbo.TopicMessages", new[] { "TopicId" });
            DropIndex("dbo.TopicMessages", new[] { "OwnerId" });
            DropTable("dbo.Topics");
            DropTable("dbo.Users");
            DropTable("dbo.TopicMessages");
        }
    }
}
