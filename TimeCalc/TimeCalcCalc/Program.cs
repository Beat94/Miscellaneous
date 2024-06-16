using System.Security.Cryptography.X509Certificates;
using TimeCalcCalc.Models;
using TimeCalcCalc;
using System.Reflection;
using TimeCalcCalc.Log;
using System.Collections.Frozen;

class Program
{
    static Config config = new();
    static Toolbox tb = new();
    static Logging logging = new Logging();
    static OutputHandler outputHandler = new OutputHandler();
    static string link = Assembly.GetExecutingAssembly().Location;

    public static void Main(string[] args)
    {
        Console.WriteLine("HelloWelt");
        logging.newEntry(LogType.Info, "Started Application");

        // Load Config
        if (String.IsNullOrEmpty(args[0]) == false)
        {
            link = args[0];
        }

        logging.newEntry(LogType.Info, $"Set link to config-file is: {link}");

        config = tb.LoadConfig(link);
        logging.newEntry(LogType.Info, $"Set config is: LocationFiles: {config.LocationFiles} | LocationOuput: {config.LocationFiles} | StartDate {config.Start} | EndDate {config.End}");

        // search files, load them and calc
        for (DateOnly dateIndicator = config.Start; dateIndicator <= config.End; dateIndicator.AddDays(1))
        { 
            string filename = tb.DateOnlyToFilename(dateIndicator);
            string input = "";
            string parsedInput = "";
            double timeResult = 0.0f;

            // find File by filename
            try
            {
                input = File.ReadLines(config.LocationFiles).First() ?? "";
            }
            catch (Exception ex)
            {
                logging.newEntry(LogType.Error, $"File {filename} not found \n {ex}");
            }

            // parse input
            parsedInput = input.TrimStart('-');
            parsedInput = parsedInput.TrimStart(' ');
            string[] inputSplitArray = parsedInput.Split(" | ");
            
            // maybe check if array lenghts modulo 2 is 0

            for(int i = 0; i < inputSplitArray.Length - 1; i += 2)
            {
                TimeOnly timeLower = TimeOnly.Parse(inputSplitArray[i]);
                TimeOnly timeHigher = TimeOnly.Parse(inputSplitArray[i+1]);
                // add time for each part
                timeResult += tb.TimeCalc(timeLower, timeHigher);
            }


            // write calculation each day in File
            outputHandler.addEntry(config.LocationOutput, input, timeResult);
        }

        // output
        tb.writeFile(config.LocationOutput + "//time.txt", outputHandler.getEntries());

        logging.newEntry(LogType.Info, $"Program End");
        //write logging to location
        string outputLogLink = config.LocationOutput ?? link;
        outputLogLink += "//programLog.txt";
        tb.writeFile(outputLogLink,logging.getLog());
    }
}