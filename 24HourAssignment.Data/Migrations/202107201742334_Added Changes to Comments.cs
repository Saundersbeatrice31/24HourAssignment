namespace _24HourAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChangestoComments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "RepId", "dbo.Reply");
            DropForeignKey("dbo.Reply", "Comment_Id", "dbo.Comment");
            DropIndex("dbo.Comment", new[] { "RepId" });
            DropIndex("dbo.Reply", new[] { "Comment_Id" });
            RenameColumn(table: "dbo.Reply", name: "Comment_Id", newName: "ComId");
            AlterColumn("dbo.Reply", "ComId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reply", "ComId");
            AddForeignKey("dbo.Reply", "ComId", "dbo.Comment", "Id", cascadeDelete: true);
            DropColumn("dbo.Comment", "RepId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "RepId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reply", "ComId", "dbo.Comment");
            DropIndex("dbo.Reply", new[] { "ComId" });
            AlterColumn("dbo.Reply", "ComId", c => c.Int());
            RenameColumn(table: "dbo.Reply", name: "ComId", newName: "Comment_Id");
            CreateIndex("dbo.Reply", "Comment_Id");
            CreateIndex("dbo.Comment", "RepId");
            AddForeignKey("dbo.Reply", "Comment_Id", "dbo.Comment", "Id");
            AddForeignKey("dbo.Comment", "RepId", "dbo.Reply", "Id", cascadeDelete: true);
        }
    }
}
