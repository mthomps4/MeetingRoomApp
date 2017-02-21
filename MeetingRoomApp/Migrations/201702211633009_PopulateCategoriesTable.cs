namespace MeetingRoomApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(Id,CategoryName) VALUES(1,'Information')");
            Sql("INSERT INTO Categories(Id,CategoryName) VALUES(2,'Q&A')");
            Sql("INSERT INTO Categories(Id,CategoryName) VALUES(3,'Social')");
            Sql("INSERT INTO Categories(Id,CategoryName) VALUES(4,'Celebration')");

        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN(1,2,3,4)");
        }
    }
}
