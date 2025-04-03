using SQL_Result_To_Query.DataModels;

namespace SQL_Result_To_Query;

public class Toolset
{
    public bool CheckColumsCount(Columns columnOption, string line)
    {
        // Split the line into an array of strings
        string[] columns = line.Split(';');
        // Check if the number of columns in the line matches the number of column options
        if (columns.Length != columnOption.columnOptions.Count)
        {
            return false;
        }

        return true;
    }
}
