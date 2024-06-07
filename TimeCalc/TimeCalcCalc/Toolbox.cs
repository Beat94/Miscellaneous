using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TimeCalcCalc.Models;

namespace TimeCalcCalc;

public class Toolbox
{

    public string DateOnlyToFilename(DateOnly date)
    {
        string dateFormatted = Convert.ToString(date.ToString("dd-MM-yy"));
        return $"today_{dateFormatted}.txt";
    }

    public Config InputToConfig(Input input)
    {
        Config config = new();

        try
        {
            config = new()
            {
                LocationFiles = input.LocationFiles,
                LocationOutput = input.LocationOutput,
                Start = DateOnly.Parse(input.Start),
                End = DateOnly.Parse(input.End)
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return config;
    }

    public Config LoadConfig(string link)
    {
        Input input = new();
        Config output = new();
        bool inputFalse = false;

        try 
        { 
            string jsonString = File.ReadAllText(link);
            input = JsonSerializer.Deserialize<Input>(jsonString)!;
        }
        catch (Exception ex) 
        { 
            inputFalse = true;
            Console.WriteLine(ex.Message);
        }

        if (inputFalse == false)
        {
            output = InputToConfig(input);
        }

        return output;
    }

    public double TimeCalc(TimeOnly timeLower, TimeOnly timeHigher)
    {
        TimeSpan timeSpan = timeHigher - timeLower;
        return timeSpan.TotalHours;
    }

    public void writeFile(string location, string output)
    {
        File.WriteAllText(location, output);
    }
}
