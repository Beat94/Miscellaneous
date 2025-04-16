using FileScraper.DataModel;
using System.Reflection;
using System.Text.Json;

namespace FileScraper;

public class Worker
{
    public void DoWork()
    {
        List<(string Link, string BusinessCode, string docNum)> outputList = new();

        string homepath = "C:\\[Homepath]";
        string outputFileName = $"{homepath}\\OutputCSharp.txt";
        string[] file = Directory.GetFiles(homepath, "*.json", SearchOption.AllDirectories);
        string pathExec = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        string filterContent = File.ReadAllText($"{pathExec}\\Files\\FilterLists.json");
        Filter filters = JsonSerializer.Deserialize<Filter>(filterContent);

        foreach (string fileName in file)
        {
            Console.WriteLine(fileName);
            string fileContent = File.ReadAllText(fileName);
            JsonFile fileObject = JsonSerializer.Deserialize<JsonFile>(fileContent)
                ?? throw new InvalidOperationException("Failed to deserialize JSON file.");

            foreach (Doc doc in fileObject.Document)
            {
                foreach (string template in filters.TemplateList)
                {
                    foreach (string BusinessCode in filters.BusinessCase)
                    {
                        string templateLikeRequest = template.Replace("DIG_", "").Replace(".", "_");

                        if (templateLikeRequest.Equals(doc.Header.dokumentnr) && BusinessCode.Equals(doc.Dms?.GvfCode))
                        {
                            Console.WriteLine($"Header: {doc.Header.dokumentnr}");
                            Console.WriteLine($"DMS Business-Code: {doc.PrintSys?.BusinessCode}");
                            outputList.Add((fileName, BusinessCode, template));
                        }
                    }
                }
            }
        }

        outputHelper(filters, outputList, outputFileName);
    }

    private void outputHelper(
        Filter filters,
        List<(string Link, string BusinessCode, string docNum)> outputList,
        string outputFileName)
    {
        string output = string.Empty;

        foreach (string template in filters.TemplateList)
        {
            foreach (string BusinessCode in filters.BusinessCase)
            {
                string templateLikeRequest = template.Replace("BusinessCode_", "").Replace(".", "_");

                List<(string Link, string BusinessCode, string docNum)> filteredList = outputList
                    .Where(x => x.BusinessCode.Equals(BusinessCode) && x.docNum.Equals(template))
                    .ToList();

                output += $"BusinessCode: {BusinessCode} - Template: {template}\n";

                foreach ((string Link, string BusinessCode, string docNum) listelement in filteredList)
                {
                    output += $"{listelement.Link} \t\t {listelement.BusinessCode} \t\t {listelement.docNum}\n";
                }
            }
        }

        File.WriteAllText(outputFileName, output);
    }
}
