using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Application;

internal class Program
{
    internal static void Main()
    {
        string link = "Test.json";
        string json = System.IO.File.ReadAllText(link);
        Sys1 sys = new();
        JObject output = sys.SetNewGuids(JObject.Parse(json), ["asdf", "asdf"]);

        Console.WriteLine("Hello, World 2!");
    }
}
