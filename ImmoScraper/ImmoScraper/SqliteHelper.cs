using Microsoft.Data.Sqlite;

public class SqliteHelper
{
    public void openFile(string link)
    {
        using var connection = new SqliteConnection($"Data Source={link}//immoscraper.db");
        connection.Open();

        using var command = connection.CreateCommand();
        /*
         * CREATE TABLE IF NOT EXISTS Immobilien (...); 
         */
        command.CommandText("");
    }
}