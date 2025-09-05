using ADOScripter.Models;
using System.Net;

namespace ADOScripter;

public class TestCaseCreator
{
    // Pseudocode:
    // 1. Add a new parameter to addTestcases to accept a list of additional step strings.
    // 2. In the steps XML, insert each additional step as a <step> node after the default steps.
    // 3. Ensure the 'last' attribute and step ids are updated accordingly.

    // Implementation:
    public List<object> addTestcases(List<CSVModel> testCaseList, int featureId, ConfigModel configModel)
    {
        int counter = 0;
        List<object> outputList = new();

        foreach (CSVModel inputModel in testCaseList)
        {
            List<object> testCaseInstructions = new();

            testCaseInstructions.Add(
                new
                {
                    op = "add",
                    path = "/fields/System.Title",
                    value = $"DT-{counter.ToString()}: Testcase - {inputModel.Titelergaenzung}"
                });


            testCaseInstructions.Add(
                new
                {
                    op = "add",
                    path = "/fields/System.AreaPath",
                    value = configModel.AreaPath
                });

            testCaseInstructions.Add(
                new
                {
                    op = "add",
                    path = "/fields/System.IterationPath",
                    value = configModel.IterationPath
                });

            testCaseInstructions.Add(
                new
                {
                    op = "add",
                    path = "/relations/-",
                    value = new
                    {
                        rel = "Microsoft.VSTS.Common.TestedBy-Reverse",
                        url = $"https://dev.azure.com/{configModel.Organization}/_apis/wit/workItems/{featureId}",
                        attributes = new
                        {
                            comment = "Testfall wird von diesem Workitem getestet"
                        }
                    }
                });

            // Build steps XML with additional steps
            int stepId = 1;
            var stepsXml = new System.Text.StringBuilder();
            stepsXml.AppendLine($"<steps id='0' last='3'>");

            // Default steps
            stepsXml.AppendLine($@"
                <step id='{stepId++}' type='ActionStep'>
                    <parameterizedString isformatted='true'>Vorbedingung
{Vorbedingung(inputModel)}</parameterizedString>
                    <parameterizedString isformatted='true'></parameterizedString>
                </step>");
            stepsXml.AppendLine($@"
                <step id='{stepId++}' type='ActionStep'>
                    <parameterizedString isformatted='true'>Testablauf
Das Programm wird getriggert</parameterizedString>
                    <parameterizedString isformatted='true'></parameterizedString>
                </step>");
            stepsXml.AppendLine($@"
                <step id='{stepId++}' type='ActionStep'>
                    <parameterizedString isformatted='true'>Prüfung
{Pruefkriterium(inputModel)}</parameterizedString>
                    <parameterizedString isformatted='true'></parameterizedString>
                </step>");

            stepsXml.AppendLine("</steps>");

            testCaseInstructions.Add(
                new
                {
                    op = "add",
                    path = "/fields/Microsoft.VSTS.TCM.Steps",
                    value = stepsXml.ToString()
                });

            outputList.Add(testCaseInstructions);
            counter++;
        }

        return outputList;
    }

    private string Pruefkriterium(CSVModel inputModel)
    {
        string output = $@"Es ist folgendes zu prüfen:
- Versandquelle: {inputModel.Versandquelle}
- Brief: {inputModel.Brief}
- Talon: {(inputModel.Talon ? "ja" : "nein")}
- Broschüre: {(inputModel.Broschure ? "ja" : "nein")}";
        return output;
    }

    private string Vorbedingung(CSVModel inputModel)
    {
        string output = $"Die Person ist {inputModel.AlterVersPerson} Jahre alt\n";

        if (inputModel.BasisVorsorge && !inputModel.MultipleBasisvorsorge)
        {
            output += "Die Person hat eine Basisvorsorge\n";
        }
        else if (inputModel.BasisVorsorge && inputModel.MultipleBasisvorsorge)
        {
            output += "Die Person hat mehrere Basisvorsorgen\n";
        }

        if (inputModel.ZusatzVorsorge && !inputModel.MultipleZusatzvorsorge)
        {
            output += "Die Person hat eine Zusatzvorsorge\n";
        }
        else if (inputModel.ZusatzVorsorge && inputModel.MultipleZusatzvorsorge)
        {
            output += "Die Person hat mehrere Zusatzvorsorgen\n";
        }

        if (inputModel.isFZP || inputModel.is1e || inputModel.isAvisierungPensionierung)
        {
            output += "Der Vertrag ist ";

            if (inputModel.isFZP)
            {
                output += "eine Freizügigkeitspolic\n";
            }
            else if (inputModel.is1e)
            {
                output += "1e\n";
            }

            if (inputModel.isAvisierungPensionierung)
            {
                output += "Die Person wird pensioniert (GF 'Avisierung Pensionierung' ist gestartet)";
            }
        }

        return output;
    }


}

