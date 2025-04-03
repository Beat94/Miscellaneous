using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using SQL_Result_To_Query.DataModels;

namespace SQL_Result_To_Query;
public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            throw new Exception("Error: Invalid number of arguments.");
        }

        /*
         *  Uses System.IO to read a CSV file
         *  and convert it to a string array
         */
        string[] inputCSVLines = File.ReadAllLines(args[0]);
        Toolset toolset = new();


        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        // Uses System.Text.Json to deserialize a JSON file
        string jsonString = File.ReadAllText(args[1]);
        Columns? columnOptions = JsonSerializer.Deserialize<Columns>(jsonString, options);

        if (columnOptions == null)
        {
            throw new Exception("Error: Data is empty.");
        }

        if (!toolset.CheckColumsCount(columnOptions, inputCSVLines[0]))
        {
            throw new Exception("Error: Column count does not match.");
        }

        string outputString = csvToValues(inputCSVLines, columnOptions);

        File.WriteAllText(args[2], outputString);
    }

    static string csvToValues(string[] csvInput, Columns options)
    {
        string output = string.Empty;

        foreach (string line in csvInput)
        {
            output += csvLineToOutput(line, options) + ",\n";
        }

        if (output.EndsWith(",\n"))
        {
            output = output.Remove(output.Length - 2);
        }

        return output;
    }

    static string csvLineToOutput(string input, Columns options)
    {
        string[] columns = input.Split(';');
        string output = "(";

        for (int i = 0; i < options.columnOptions.Count; i++)
        {
            output += logicToOutput(columns[i], options.columnOptions.ElementAt(i)) + ",";
        }

        // Remove the last comma
        if (output.EndsWith(","))
        {
            output = output.Remove(output.Length - 1);
        }

        output += ")";

        return output;
    }

    static string logicToOutput(string input, OptionEnum optionEnum)
    {
        string output = string.Empty;

        switch (optionEnum)
        {
            case OptionEnum.String:
                output = $"'{input}'";
                break;
            case OptionEnum.Number:
                output = input;
                break;
            case OptionEnum.Empty:
                output = input;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(optionEnum), optionEnum, null);
        }

        return output;
    }
}
