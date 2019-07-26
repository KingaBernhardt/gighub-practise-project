namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "Genre_Id", c => c.Byte());
            CreateIndex("dbo.Gigs", "Genre_Id");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropColumn("dbo.Gigs", "Genre_Id");
        }
    }
}
