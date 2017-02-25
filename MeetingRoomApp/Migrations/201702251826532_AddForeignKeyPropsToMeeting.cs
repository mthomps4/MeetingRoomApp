namespace MeetingRoomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropsToMeeting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Meetings", new[] { "leadBy_Id" });
            RenameColumn(table: "dbo.Meetings", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Meetings", name: "IX_Category_Id", newName: "IX_CategoryId");
            AddColumn("dbo.Meetings", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Meetings", "leadBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Meetings", "leadBy_Id");
            AddForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Meetings", new[] { "leadBy_Id" });
            AlterColumn("dbo.Meetings", "leadBy_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Meetings", "UserId");
            RenameIndex(table: "dbo.Meetings", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Meetings", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Meetings", "leadBy_Id");
            AddForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
