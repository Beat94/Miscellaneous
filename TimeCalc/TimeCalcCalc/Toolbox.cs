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
    public Config InputToConfig(Input input)
    {
        Config config = new();

        try
        {
            config = new()
            {
                Location = input.location,
                Start = DateOnly.Parse(input.start),
                End = DateOnly.Parse(input.end)
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return config;
    }

    public Config loadConfig(string link)
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
}
