namespace MeetingRoomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meetings", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Meetings", new[] { "Category_Id" });
            DropIndex("dbo.Meetings", new[] { "leadBy_Id" });
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Meetings", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Meetings", "Category_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Meetings", "leadBy_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Meetings", "Category_Id");
            CreateIndex("dbo.Meetings", "leadBy_Id");
            AddForeignKey("dbo.Meetings", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetings", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Meetings", new[] { "leadBy_Id" });
            DropIndex("dbo.Meetings", new[] { "Category_Id" });
            AlterColumn("dbo.Meetings", "leadBy_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Meetings", "Category_Id", c => c.Byte());
            AlterColumn("dbo.Meetings", "Venue", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            CreateIndex("dbo.Meetings", "leadBy_Id");
            CreateIndex("dbo.Meetings", "Category_Id");
            AddForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Meetings", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
