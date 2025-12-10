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
    static string link = $"C:\\Devlopment\\private\\Miscellaneous\\TimeCalc\\TimeCalcCalc\\config.conf";

    public static void Main(string[] args)
    {
        int pointer = 0;
        logging.newEntry(LogType.Info, "Started Application");

        // Load Config
        if (args.Length > 0)
        {
            link = args[0];
        }

        logging.newEntry(LogType.Info, $"Set link to config-file is: {link}");

        config = tb.LoadConfig(link);
         

        // search files, load them and calc
        for (DateOnly dateIndicator = config.Start; dateIndicator <= config.End; dateIndicator = dateIndicator.AddDays(1))
        { 
            string filename = tb.DateOnlyToFilename(dateIndicator);
            string input = "";
            string parsedInput = "";
            double timeResult = 0.0f;

            // find File by filename
            try
            {
                StreamReader streamRead = new StreamReader($"{config.LocationFiles}\\{filename}");
                input = streamRead.ReadLine();
                streamRead.Close();
            }
            catch (Exception ex)
            {
                logging.newEntry(LogType.Error, $"File {filename} not found \n {ex}");
                continue;
            }

            // parse input
            parsedInput = input.TrimStart('-');
            parsedInput = parsedInput.TrimStart(' ');
            string[] inputSplitArray = parsedInput.Split(" | ");
            List<TimeOnly> inputSplitTimeArray = new List<TimeOnly>();
            string formattedInput = String.Empty;

            foreach(string item in inputSplitArray)
            {
                string[] splitItem = item.Split(" - ");
                inputSplitTimeArray.Add(TimeOnly.Parse(splitItem[0]));
                inputSplitTimeArray.Add(TimeOnly.Parse(splitItem[1]));

                if (formattedInput.Length == 0)
                {
                    formattedInput = $"{splitItem[0]} - {splitItem[1]}";
                }
                else
                {
                    formattedInput += $" | {splitItem[0]} - {splitItem[1]}";
                }
            }

            // maybe check if array lenghts modulo 2 is 0
            for(int i = 0; i < inputSplitTimeArray.Count - 1; i += 2)
            {
                //TimeOnly timeLower = TimeOnly.Parse(inputSplitTimeArray.[i]);
                //TimeOnly timeHigher = TimeOnly.Parse(inputSplitTimeArray[i+1]);
                TimeOnly timeLower = inputSplitTimeArray[i];
                TimeOnly timeHigher = inputSplitTimeArray[i+1];
                // add time for each part
                timeResult += tb.TimeCalc(timeLower, timeHigher);
            }

            pointer++;

            if(pointer > 999)
            {
                break;
            }

            // write calculation each day in File
            outputHandler.addEntry($"{config.LocationFiles}\\{filename}", formattedInput, timeResult);
        }

        // output
        tb.writeFile(config.LocationOutput + "\\time.txt", outputHandler.getEntries());

        logging.newEntry(LogType.Info, $"Program End");
        //write logging to location
        string outputLogLink = config.LocationOutput ?? link;
        outputLogLink += "\\programLog.txt";
        tb.writeFile(outputLogLink,logging.getLog());
    }
}