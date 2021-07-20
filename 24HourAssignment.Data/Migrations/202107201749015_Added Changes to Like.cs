namespace _24HourAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChangestoLike : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "LikeId", "dbo.Like");
            DropForeignKey("dbo.Like", "Post_Id", "dbo.Post");
            DropIndex("dbo.Post", new[] { "LikeId" });
            DropIndex("dbo.Like", new[] { "Post_Id" });
            RenameColumn(table: "dbo.Like", name: "Post_Id", newName: "PostId");
            AlterColumn("dbo.Like", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Like", "PostId");
            AddForeignKey("dbo.Like", "PostId", "dbo.Post", "Id", cascadeDelete: true);
            DropColumn("dbo.Post", "LikeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "LikeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropIndex("dbo.Like", new[] { "PostId" });
            AlterColumn("dbo.Like", "PostId", c => c.Int());
            RenameColumn(table: "dbo.Like", name: "PostId", newName: "Post_Id");
            CreateIndex("dbo.Like", "Post_Id");
            CreateIndex("dbo.Post", "LikeId");
            AddForeignKey("dbo.Like", "Post_Id", "dbo.Post", "Id");
            AddForeignKey("dbo.Post", "LikeId", "dbo.Like", "Id", cascadeDelete: true);
        }
    }
}
