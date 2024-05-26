using System.Security.Cryptography.X509Certificates;
using TimeCalcCalc.Models;
using TimeCalcCalc;
using System.Reflection;

class Program
{
    Config config = new();
    Toolbox tb = new();
    string link = Assembly.GetExecutingAssembly().Location;

    public void Main(string[] args)
    {
        Console.WriteLine("HelloWelt");

        // Load Config
        if (String.IsNullOrEmpty(args[0]) == false)
        {
            link = args[0];
        }

        config = tb.LoadConfig(link);

        // search files, load them and calc
        for (DateOnly dateIndicator = config.Start; dateIndicator <= config.End; dateIndicator.AddDays(1))
        { 
            string filename = tb.DateOnlyToFilename(dateIndicator);
            // find File by filename
        }

        // output

    }
}