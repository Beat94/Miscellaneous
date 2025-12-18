using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Program
{
    private static string pat = "[PAT]";
    private static string organisation = "[organisation]";
    private static string project = "[project]";
    private static bool debug = false;
    private static string WorkItemId = "[workitemId]";
    private static string logLink = "C:\\Devlopment\\log.txt";

    public static async Task Main(string[] args)
    {
        List<string> logLists = new List<string>();
        AdoHelper adh = new AdoHelper(organisation, project, pat, debug);
        List<(string id, string workitemType)> workItems = await adh.getJsonElementByAdoCall(Program.WorkItemId);
        Console.WriteLine("Workitems");
        if (Program.debug)
        {
            foreach ((string id, string workitemType) item in workItems)
            {
                Console.WriteLine($"{item.id} {item.workitemType}");
            }
        }
        Console.WriteLine($"Anzahl: {workItems.Count<(string, string)>()}");
        Console.WriteLine("Enter drücken");
        Console.ReadLine();
        foreach ((string id, string workitemType) workItem in workItems)
        {
            await adh.setWorkitemCancel(workItem.id, workItem.workitemType);
            if (Program.debug)
            {
                Console.WriteLine(workItem.id);
                Console.WriteLine("Enter drücken");
                Console.ReadLine();
            }
            logLists.Add(workItem.id + " auf abgeschlossen gesetzt");
            Console.WriteLine(workItem.id + " auf abgeschlossen gesetzt");
        }
        string logoutput = string.Empty;
        File.WriteAllLines(Program.logLink, logLists.ToArray(), Encoding.UTF8);
        Console.WriteLine("Finished");
    }
}