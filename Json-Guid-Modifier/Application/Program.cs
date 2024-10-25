using Newtonsoft.Json.Linq;

namespace Application;

internal class Program
{
    internal static void Main()
    { 
        Sys1 sys = new Sys1();

        sys.SetNewGuids(new JObject());

        Console.WriteLine("Hello, World 2!");
        Console.WriteLine($"Automatic randomized GUID: {sys.lolz().ToString()}");
    }
}
