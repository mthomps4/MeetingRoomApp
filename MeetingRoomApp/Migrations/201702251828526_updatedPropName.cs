namespace MeetingRoomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedPropName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Meetings", new[] { "leadBy_Id" });
            RenameColumn(table: "dbo.Meetings", name: "leadBy_Id", newName: "leadById");
            AlterColumn("dbo.Meetings", "leadById", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Meetings", "leadById");
            AddForeignKey("dbo.Meetings", "leadById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Meetings", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meetings", "UserId", c => c.String(nullable: false));
            DropForeignKey("dbo.Meetings", "leadById", "dbo.AspNetUsers");
            DropIndex("dbo.Meetings", new[] { "leadById" });
            AlterColumn("dbo.Meetings", "leadById", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Meetings", name: "leadById", newName: "leadBy_Id");
            CreateIndex("dbo.Meetings", "leadBy_Id");
            AddForeignKey("dbo.Meetings", "leadBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
