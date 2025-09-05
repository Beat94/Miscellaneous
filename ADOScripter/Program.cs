using ADOScripter.Models;
using Microsoft.Extensions.Configuration;

namespace ADOScripter;
public static class Program
{
    public static void Main()
    {
        int mergeToWi = 852670; // Feature ID where the test cases will be linked
        ConfigLoader configLoader = new ConfigLoader();
        ConfigModel configModel = configLoader.getConfig();
        Console.WriteLine($"{configModel.Organization}");

        CsvHelper csvHelper = new CsvHelper();
        List<CSVModel> csvModel = csvHelper.ReadCsv(
            configModel.InputFile, ';');

        if (configModel.Debug)
        {
            foreach (var item in csvModel)
            {
                Console.WriteLine($"{item.AlterVersPerson} - {item.BasisVorsorge} - {item.ZusatzVorsorge} - {item.Talon} - {item.Broschure} - {item.Titelergaenzung}");
            }
        }

        AdoRequest adoRequest = new AdoRequest(
            mergeToWi,
            configModel);

        adoRequest.CreateWorkItems(csvModel).Wait();
    }
}
