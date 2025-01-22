using Newtonsoft.Json.Linq;

namespace Application;

internal class Program
{
    internal static void Main()
    { 
        Sys1 sys = new Sys1();

        sys.SetNewGuids(new JObject(), ["asdf", "asdf"]);

        Console.WriteLine("Hello, World 2!");
    }
}
