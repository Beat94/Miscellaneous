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

        config = tb.loadConfig(link);

        // search files, load them and calc
        

        // output

    }
}