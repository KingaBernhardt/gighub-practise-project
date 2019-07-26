namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    //to have this class --> just add-migration (empty) and then add sql scripts.
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Blues')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'Rock')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'Country')");
        }
        
        //In the Down comes always the opposite of Up!
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id In (1, 2, 3, 4)");
        }
    }
}
