using Microsoft.Extensions.Configuration;

namespace FileScraper;
public class Program
{
    static string homepath = "C:\\Users\\reyb\\Downloads\\digis-uat";

    static void Main()
    {
        Worker work = new();
        work.DoWork();
    }
}
