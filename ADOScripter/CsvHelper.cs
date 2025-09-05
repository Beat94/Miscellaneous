using ADOScripter.Models;
using System.Runtime.InteropServices;

namespace ADOScripter;

public class CsvHelper
{
    public List<CSVModel> ReadCsv(string link, char delimiter)
    {
        List<CSVModel> csvData = new();

        // if there is a header, skip the first line
        int counter = 0;

        Helper helper = new Helper();

        try
        {
            foreach (string line in File.ReadLines(link))
            {
                if (counter > 0)
                {
                    List<string> values = line.Split(delimiter).ToList();

                    CSVModel csvmodel = new();
                    csvmodel.AlterVersPerson = int.Parse(values[0]);
                    csvmodel.BasisVorsorge = helper.boolHelper(values[1]);
                    csvmodel.ZusatzVorsorge = helper.boolHelper(values[2]);
                    csvmodel.MultipleBasisvorsorge = helper.boolHelper(values[3]);
                    csvmodel.MultipleZusatzvorsorge = helper.boolHelper(values[4]);
                    csvmodel.is1e = helper.boolHelper(values[5]);
                    csvmodel.isFZP = helper.boolHelper(values[6]);
                    csvmodel.isAvisierungPensionierung = helper.boolHelper(values[7]);
                    csvmodel.Versandquelle = values[8];
                    csvmodel.Brief = values[11];
                    csvmodel.Talon = helper.crossToBoolHelper(values[12]);
                    csvmodel.Broschure = helper.crossToBoolHelper(values[13]);
                    csvmodel.Titelergaenzung = values[14];

                    csvData.Add(csvmodel);
                }

                counter++;
            }
        }
        catch
        {
            Console.WriteLine("Error reading CSV file.");
        }

        return csvData;
    }
}
