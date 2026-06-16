public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");
        ScrapingManager sm = new();
        sm.start();
    }
}
