namespace MeetingRoomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMeetingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Category_Id = c.Byte(),
                        leadBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.leadBy_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.leadBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetings", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Meetings", new[] { "leadBy_Id" });
            DropIndex("dbo.Meetings", new[] { "Category_Id" });
            DropTable("dbo.Meetings");
            DropTable("dbo.Categories");
        }
    }
}
