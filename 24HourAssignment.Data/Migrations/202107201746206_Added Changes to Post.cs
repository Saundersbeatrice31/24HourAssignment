namespace _24HourAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChangestoPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "CommId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "Post_Id", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "Post_Id" });
            DropIndex("dbo.Post", new[] { "CommId" });
            RenameColumn(table: "dbo.Comment", name: "Post_Id", newName: "PostId");
            AlterColumn("dbo.Comment", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "PostId");
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "Id", cascadeDelete: true);
            DropColumn("dbo.Post", "CommId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "CommId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "PostId" });
            AlterColumn("dbo.Comment", "PostId", c => c.Int());
            RenameColumn(table: "dbo.Comment", name: "PostId", newName: "Post_Id");
            CreateIndex("dbo.Post", "CommId");
            CreateIndex("dbo.Comment", "Post_Id");
            AddForeignKey("dbo.Comment", "Post_Id", "dbo.Post", "Id");
            AddForeignKey("dbo.Post", "CommId", "dbo.Comment", "Id", cascadeDelete: true);
        }
    }
}
