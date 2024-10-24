namespace Application;

internal class Program
{
    internal static void Main()
    { 
        Sys1 sys = new Sys1();
        sys.inputString = "Dies ist ein Input";

        Console.WriteLine("Hello, World 2!");

        Console.WriteLine($"Automatic randomized GUID: {sys.lolz().ToString()}");
        Console.WriteLine($"{sys.inputString}");
    }
}
