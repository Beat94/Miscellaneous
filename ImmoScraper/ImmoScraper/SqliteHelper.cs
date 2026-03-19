using Microsoft.Data.Sqlite;

public class SqliteHelper
{
    public void openFile(string link)
    {
        using var connection = new SqliteConnection($"Data Source={link}//immoscraper.db");
        connection.Open();

        
        // Todo: SQL 1. Call of table 
        
        using SqliteCommand command = connection.CreateCommand();
        /*
         * CREATE TABLE IF NOT EXISTS Immobilien (...); 
         */
        command.CommandText = """
                                CREATE TABLE IF NOT EXISTS Immobilien (...); 
                              """;
    }
    
    // Todo: write on table
    
    // Todo: read on table
    
    
}